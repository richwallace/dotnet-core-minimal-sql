# dotnet-core-minimal-sql
ASP.NET 6 - Minimal API with SQL Database

Quick and dirty minimal API talking to SQL Server.

Limitations of Minimal APIs compared to APIs w/Controllers
- No support for filters: For example, no support for IAsyncAuthorizationFilter, IAsyncActionFilter, IAsyncExceptionFilter, IAsyncResultFilter, and IAsyncResourceFilter.
- No support for model binding, i.e. IModelBinderProvider, IModelBinder. Support can be added with a custom binding shim.
- No support for binding from forms
- No built-in support for validation, i.e. IModelValidator
- No support for application parts or the application model
- No built-in view rendering support
- No support for JsonPatch
- No support for OData
- No support for ApiVersioning
