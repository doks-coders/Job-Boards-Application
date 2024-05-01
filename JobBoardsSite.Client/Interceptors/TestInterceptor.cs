namespace JobBoardsSite.Client.Interceptors
{
	public class TestInterceptor : DelegatingHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			request.Headers.Add("Custom-Header", "Interceptor-Added");

			// Process the request further
			var response = await base.SendAsync(request, cancellationToken);

			// Modify the response if needed before returning
			// For example, you can read and log the response content here

			return response;
		}
	}
}

