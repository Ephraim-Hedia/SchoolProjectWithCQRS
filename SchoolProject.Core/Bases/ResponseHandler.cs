namespace SchoolProject.Core.Bases
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {

        }
        public Response<T> Updated<T>(T entity, object Meta = null)
        {
            return new Response<T>(entity)
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Updated successfully",
                Meta = Meta
            };
        }
        public Response<T> Deleted<T>(string? message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message == null ? "Deleted successfully" : message,
            };
        }
        public Response<T> Success<T>(T entity, object Meta = null)
        {
            return new Response<T>(entity)
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Done successfully",
                Meta = Meta
            };
        }
        public Response<T> Unauthorized<T>(string? message)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = message == null ? "Unauthorized" : message,
            };
        }
        public Response<T> UnprocessableEntity<T>(string? message)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message == null ? "Unprocessable Entity" : message,
            };
        }
        public Response<T> BadRequest<T>(string? message)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message == null ? "Bad Request" : message,
            };
        }
        public Response<T> NotFound<T>(string? message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not found" : message,
            };
        }
        public Response<T> Updated<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Updated successfully",
            };
        }
        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>(entity)
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created successfully",
                Meta = Meta
            };
        }




    }
}
