using MediatR;

namespace Identity.Application.Features.Files;

public class FileUploadCommand : IRequest<FileUploadResponse>
{
    public string Data { get; set; } = default!;
    public string Extension { get; set; } = default!;
    public string Name { get; set; } = default!;
}