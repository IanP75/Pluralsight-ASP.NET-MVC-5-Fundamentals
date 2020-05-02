## ASP.NET MVC 5 Fundamentals

#### Section 1
Introduction

#### Section 2: New MVC application
Controller handles http requests.

Passes to view via `View()` method. `View()` returns ActionResult

View can accept model, `View(model)`, which can then be used in view.

In view, use `@` to write C# code.

Can tell view what type the model is, so can use strong types e.g.

	@model IEnumerable<OdeToFood.Data.Models.Restaurant>

can then write '@Model.Count()'.


#### Section 3: Application startup and Configuration
Every web project has a global.asax, with a .cs.

Inherits 'HttpApplication', handles events like application startup.

Calls classes in App_Start folder, to initialise things like bundles (jquery, bootstrap, etc.) and routes.

Access via e.g. ~/bundles/bootstrap.

Use `RegisterRoutes()` to configure routing.
Can ingore route with `IgnoreRoute(path)`.
Use `MapRoute()` to map urls to routes.

`web.config appsettings` contains flags for MVC, in key value pairs. 
Reference via `ConfigurationManager.AppSettings[key]`.

Dependency Inversion Principle means we inject references into constructors. Need an Inversion of Control container.

Can use Autofac.MVC5 (extends Autofac).

#### Section 4: MVC Controllers
Can access query string vaules via` HTTPContext.RequestQueryString`, but MVC will do it for you if passed to the method.
Note that MVC will automatically protect against dangerous content.

Two types of controller, one for Web UI, that uses `View()`, one for APIs that produces json or XML.

API methods match http requests, e.g. Get, Post, etc. Route just contains controller.

Needs separate startup configuration from UI.
