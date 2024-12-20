using Aspire.Hosting.Dapr;

var builder = DistributedApplication.CreateBuilder(args);

DaprSidecarOptions sidecarOptions = new()
{
    DaprGrpcPort = 50001,
    DaprHttpPort = 3500,
    MetricsPort = 9090
};

builder.AddProject<Projects.Product>("productapi").WithDaprSidecar(sidecarOptions);

builder.AddProject<Projects.User>("userapi");


builder.Build().Run();
