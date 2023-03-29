// See https://aka.ms/new-console-template for more information
using System.Threading.Channels;

Console.WriteLine("Hello, Channel World!");

var channel = Channel.CreateBounded(
    new BoundedChannelOptions(20)
    {
        SingleWriter = true,
        SingleReader = false,
        AllowSynchronousContinuations = false,
        FullMode = BoundedChannelFullMode.DropWrite
    },
    static void (string dropped) =>
        Console.WriteLine($"Dropped '{dropped}'"));

var channelWriter = channel.Writer;
var producer = Task.Run((async () =>
{
    foreach (var i in Enumerable.Range(1, 30))
        await WriteItemToChannel(channelWriter, $"ORG.GROUP.{i}");

    channelWriter.Complete();
}));

var consumer1 = Task.Run(async () =>
{
    while (!channel.Reader.Completion.IsCompleted)
        await ReadItemFromChannel("C1", channel.Reader, 800);
});

var consumer2 = Task.Run(async () =>
{
    while (!channel.Reader.Completion.IsCompleted)
        await ReadItemFromChannel("C2", channel.Reader, 1100);
});

Task.WaitAll(producer, consumer1, consumer2);

static async Task ReadItemFromChannel(string consumer, ChannelReader<string> channelReader, int durationInMilliseconds)
{
    var groupName = await channelReader.ReadAsync();
    Console.WriteLine($"{consumer} processed '{groupName}'");
    await Task.Delay(durationInMilliseconds);
}

static async Task WriteItemToChannel(ChannelWriter<string> channelWriter, string groupName)
{
    Console.WriteLine($"Adding '{groupName}'...");
    await channelWriter.WriteAsync(groupName);
    await Task.Delay(100);
}