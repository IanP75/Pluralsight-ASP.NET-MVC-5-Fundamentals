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

#### Section 5: MVC Models

A model is similar to a database entity, a view model is for data specific to the view.
A view model can contain entities as well as other data.

ModelState contains the state of the model after model binding 
(the part where it takes data from the form, query string, etc.).

Model binding checks data annotations.

#### Section 6: Entity Framework in MVC

Can implement optimistic concurrency with `db.Entry`, this tracks the item.

Entity Framework will create the database if none there, using the DBContext to create the objects.

#### Section 7: Razor views

###### Code in html

Use @ with curly braces for code blocks:

    @{
    
    }

VS will work out what is markup (most of the time).

`@:` explicitly renders as html.

Can just type straight after the `@` (this is an expression):

    @Model.Count();

Raw html can be emitted with:

    @Html.Raw("")

Can escape `@` with `@@`. 

`@()` explicitly makes this code.

###### Layout
Layout property of view tells it which layout to use. This controls the outer bits and styling.
Default comes from `_ViewStart.cshtml`, which points to `~/Views/Shared/_Layout.cshtml`.

`_ViewStart` is hierarchical, it looks for them in each folder.

`@RenderBody()` is found in layouts, and is a call to render the inner view.

`@RenderSection("section name")` lets you add your own custom sections. Implement with 

    @section sectionname {
        my custom markup
    }
in your view.

###### Partial views

Partial views allow you to make chunks of reusable markup. Render with `@Html.Partial("_partialName", model)`. (underscore prefix is the convention for shared layouts).

Create in Shared folder so can be used in any page.

###### ViewBag

ViewBag is a dynamic data structure that can be accessed in a view, so is basically a dictionary of key value pairs.

Can set with `ViewBag.MyProperty = "Anything"` and access via `ViewBag.MyProperty`.

ViewBag saves working with lots of different models for each page, it is common to all pages.

###### Passing data between requests

Use TempData["key"] to pass data across requests. Only lasts for the next request.

#### Section 8: Front End Frameworks

Right click project - Add - Client-Side Library...

Libraries are stored in libman.json

    "libraries": [
    {
        "library": "jquery@3.5.1",
        "destination": "lib/jquery/"
    }

This is similar to a package manager in that we dont need to source control the files, VS can download them as required.

Files in lib folder dont have versions, so can change version in libman and download new version, and use straight away.

#### Section 9: Deploying MVC Applications

RIght click website - Publish...

Use Web.[release].config to set attributes for publish e.g. connection string.

    xdt:Transform="SetAttributes" xdt:Locator="Match(name)"

Find by using the specified name and set the attributes.

If you application pool is running under the ApplicationPoolIdentity, give it access to SQL Server via the Login 

    [IIS APPPOOL\AppPoolName]

Needs the server role [dbcreator] to create the database.