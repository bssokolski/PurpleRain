[33mcommit 4d215fc5d94e694165def60f7235b960e4a86228[m[33m ([m[1;36mHEAD -> [m[1;32mIan[m[33m)[m
Author: Ian Mills <iandmills1@gmail.com>
Date:   Mon Nov 18 13:24:22 2019 -0500

    added PurpleRain.WebAPI controllers

[1mdiff --git a/PurpleRain.Data/App.config b/PurpleRain.Data/App.config[m
[1mindex f4754fe..bc66c5f 100644[m
[1m--- a/PurpleRain.Data/App.config[m
[1m+++ b/PurpleRain.Data/App.config[m
[36m@@ -14,4 +14,12 @@[m
       <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />[m
     </providers>[m
   </entityFramework>[m
[32m+[m[32m  <runtime>[m
[32m+[m[32m    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">[m
[32m+[m[32m      <dependentAssembly>[m
[32m+[m[32m        <assemblyIdentity name="System.Web.Cors" publicKeyToken="31bf3856ad364e35" culture="neutral" />[m
[32m+[m[32m        <bindingRedirect oldVersion="0.0.0.0-5.2.7.0" newVersion="5.2.7.0" />[m
[32m+[m[32m      </dependentAssembly>[m
[32m+[m[32m    </assemblyBinding>[m
[32m+[m[32m  </runtime>[m
 </configuration>[m
\ No newline at end of file[m
[1mdiff --git a/PurpleRain.Data/PurpleRain.Data.csproj b/PurpleRain.Data/PurpleRain.Data.csproj[m
[1mindex 8cbfc7c..9ba0716 100644[m
[1m--- a/PurpleRain.Data/PurpleRain.Data.csproj[m
[1m+++ b/PurpleRain.Data/PurpleRain.Data.csproj[m
[36m@@ -43,9 +43,33 @@[m
     <Reference Include="Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
       <HintPath>..\packages\Microsoft.AspNet.Identity.EntityFramework.2.2.2\lib\net45\Microsoft.AspNet.Identity.EntityFramework.dll</HintPath>[m
     </Reference>[m
[32m+[m[32m    <Reference Include="Microsoft.Owin, Version=4.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.Owin.4.0.1\lib\net45\Microsoft.Owin.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="Microsoft.Owin.Cors, Version=4.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.Owin.Cors.4.0.1\lib\net45\Microsoft.Owin.Cors.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="Newtonsoft.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Newtonsoft.Json.6.0.4\lib\net45\Newtonsoft.Json.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="Owin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f0ebd12fd5e55cc5, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Owin.1.0\lib\net40\Owin.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
     <Reference Include="System" />[m
     <Reference Include="System.ComponentModel.DataAnnotations" />[m
     <Reference Include="System.Core" />[m
[32m+[m[32m    <Reference Include="System.Net.Http.Formatting, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.WebApi.Client.5.2.7\lib\net45\System.Net.Http.Formatting.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="System.Web.Cors, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.Cors.5.2.7\lib\net45\System.Web.Cors.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="System.Web.Http, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.WebApi.Core.5.2.7\lib\net45\System.Web.Http.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="System.Web.Http.Cors, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.WebApi.Cors.5.2.7\lib\net45\System.Web.Http.Cors.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
     <Reference Include="System.Xml.Linq" />[m
     <Reference Include="System.Data.DataSetExtensions" />[m
     <Reference Include="Microsoft.CSharp" />[m
[1mdiff --git a/PurpleRain.Data/packages.config b/PurpleRain.Data/packages.config[m
[1mindex b5bf29b..d12d14b 100644[m
[1m--- a/PurpleRain.Data/packages.config[m
[1m+++ b/PurpleRain.Data/packages.config[m
[36m@@ -1,6 +1,14 @@[m
 ﻿<?xml version="1.0" encoding="utf-8"?>[m
 <packages>[m
   <package id="EntityFramework" version="6.1.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.Cors" version="5.2.7" targetFramework="net472" />[m
   <package id="Microsoft.AspNet.Identity.Core" version="2.2.2" targetFramework="net472" />[m
   <package id="Microsoft.AspNet.Identity.EntityFramework" version="2.2.2" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.WebApi.Client" version="5.2.7" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.WebApi.Core" version="5.2.7" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.WebApi.Cors" version="5.2.7" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.Owin" version="4.0.1" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.Owin.Cors" version="4.0.1" targetFramework="net472" />[m
[32m+[m[32m  <package id="Newtonsoft.Json" version="6.0.4" targetFramework="net472" />[m
[32m+[m[32m  <package id="Owin" version="1.0" targetFramework="net472" />[m
 </packages>[m
\ No newline at end of file[m
[1mdiff --git a/PurpleRain.Models/App.config b/PurpleRain.Models/App.config[m
[1mindex f4754fe..bc66c5f 100644[m
[1m--- a/PurpleRain.Models/App.config[m
[1m+++ b/PurpleRain.Models/App.config[m
[36m@@ -14,4 +14,12 @@[m
       <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />[m
     </providers>[m
   </entityFramework>[m
[32m+[m[32m  <runtime>[m
[32m+[m[32m    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">[m
[32m+[m[32m      <dependentAssembly>[m
[32m+[m[32m        <assemblyIdentity name="System.Web.Cors" publicKeyToken="31bf3856ad364e35" culture="neutral" />[m
[32m+[m[32m        <bindingRedirect oldVersion="0.0.0.0-5.2.7.0" newVersion="5.2.7.0" />[m
[32m+[m[32m      </dependentAssembly>[m
[32m+[m[32m    </assemblyBinding>[m
[32m+[m[32m  </runtime>[m
 </configuration>[m
\ No newline at end of file[m
[1mdiff --git a/PurpleRain.Models/PurpleRain.Models.csproj b/PurpleRain.Models/PurpleRain.Models.csproj[m
[1mindex f08f9bc..053c0ca 100644[m
[1m--- a/PurpleRain.Models/PurpleRain.Models.csproj[m
[1m+++ b/PurpleRain.Models/PurpleRain.Models.csproj[m
[36m@@ -43,9 +43,33 @@[m
     <Reference Include="Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
       <HintPath>..\packages\Microsoft.AspNet.Identity.EntityFramework.2.2.2\lib\net45\Microsoft.AspNet.Identity.EntityFramework.dll</HintPath>[m
     </Reference>[m
[32m+[m[32m    <Reference Include="Microsoft.Owin, Version=4.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.Owin.4.0.1\lib\net45\Microsoft.Owin.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="Microsoft.Owin.Cors, Version=4.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.Owin.Cors.4.0.1\lib\net45\Microsoft.Owin.Cors.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="Newtonsoft.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Newtonsoft.Json.6.0.4\lib\net45\Newtonsoft.Json.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="Owin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f0ebd12fd5e55cc5, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Owin.1.0\lib\net40\Owin.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
     <Reference Include="System" />[m
     <Reference Include="System.ComponentModel.DataAnnotations" />[m
     <Reference Include="System.Core" />[m
[32m+[m[32m    <Reference Include="System.Net.Http.Formatting, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.WebApi.Client.5.2.7\lib\net45\System.Net.Http.Formatting.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="System.Web.Cors, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.Cors.5.2.7\lib\net45\System.Web.Cors.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="System.Web.Http, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.WebApi.Core.5.2.7\lib\net45\System.Web.Http.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="System.Web.Http.Cors, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.WebApi.Cors.5.2.7\lib\net45\System.Web.Http.Cors.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
     <Reference Include="System.Xml.Linq" />[m
     <Reference Include="System.Data.DataSetExtensions" />[m
     <Reference Include="Microsoft.CSharp" />[m
[1mdiff --git a/PurpleRain.Models/packages.config b/PurpleRain.Models/packages.config[m
[1mindex b5bf29b..d12d14b 100644[m
[1m--- a/PurpleRain.Models/packages.config[m
[1m+++ b/PurpleRain.Models/packages.config[m
[36m@@ -1,6 +1,14 @@[m
 ﻿<?xml version="1.0" encoding="utf-8"?>[m
 <packages>[m
   <package id="EntityFramework" version="6.1.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.Cors" version="5.2.7" targetFramework="net472" />[m
   <package id="Microsoft.AspNet.Identity.Core" version="2.2.2" targetFramework="net472" />[m
   <package id="Microsoft.AspNet.Identity.EntityFramework" version="2.2.2" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.WebApi.Client" version="5.2.7" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.WebApi.Core" version="5.2.7" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.WebApi.Cors" version="5.2.7" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.Owin" version="4.0.1" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.Owin.Cors" version="4.0.1" targetFramework="net472" />[m
[32m+[m[32m  <package id="Newtonsoft.Json" version="6.0.4" targetFramework="net472" />[m
[32m+[m[32m  <package id="Owin" version="1.0" targetFramework="net472" />[m
 </packages>[m
\ No newline at end of file[m
[1mdiff --git a/PurpleRain.Services/App.config b/PurpleRain.Services/App.config[m
[1mindex f4754fe..bc66c5f 100644[m
[1m--- a/PurpleRain.Services/App.config[m
[1m+++ b/PurpleRain.Services/App.config[m
[36m@@ -14,4 +14,12 @@[m
       <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />[m
     </providers>[m
   </entityFramework>[m
[32m+[m[32m  <runtime>[m
[32m+[m[32m    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">[m
[32m+[m[32m      <dependentAssembly>[m
[32m+[m[32m        <assemblyIdentity name="System.Web.Cors" publicKeyToken="31bf3856ad364e35" culture="neutral" />[m
[32m+[m[32m        <bindingRedirect oldVersion="0.0.0.0-5.2.7.0" newVersion="5.2.7.0" />[m
[32m+[m[32m      </dependentAssembly>[m
[32m+[m[32m    </assemblyBinding>[m
[32m+[m[32m  </runtime>[m
 </configuration>[m
\ No newline at end of file[m
[1mdiff --git a/PurpleRain.Services/PurpleRain.Services.csproj b/PurpleRain.Services/PurpleRain.Services.csproj[m
[1mindex 29f2d22..43edf60 100644[m
[1m--- a/PurpleRain.Services/PurpleRain.Services.csproj[m
[1m+++ b/PurpleRain.Services/PurpleRain.Services.csproj[m
[36m@@ -43,9 +43,33 @@[m
     <Reference Include="Microsoft.AspNet.Identity.EntityFramework, Version=2.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
       <HintPath>..\packages\Microsoft.AspNet.Identity.EntityFramework.2.2.2\lib\net45\Microsoft.AspNet.Identity.EntityFramework.dll</HintPath>[m
     </Reference>[m
[32m+[m[32m    <Reference Include="Microsoft.Owin, Version=4.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.Owin.4.0.1\lib\net45\Microsoft.Owin.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="Microsoft.Owin.Cors, Version=4.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.Owin.Cors.4.0.1\lib\net45\Microsoft.Owin.Cors.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="Newtonsoft.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Newtonsoft.Json.6.0.4\lib\net45\Newtonsoft.Json.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="Owin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f0ebd12fd5e55cc5, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Owin.1.0\lib\net40\Owin.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
     <Reference Include="System" />[m
     <Reference Include="System.ComponentModel.DataAnnotations" />[m
     <Reference Include="System.Core" />[m
[32m+[m[32m    <Reference Include="System.Net.Http.Formatting, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.WebApi.Client.5.2.7\lib\net45\System.Net.Http.Formatting.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="System.Web.Cors, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.Cors.5.2.7\lib\net45\System.Web.Cors.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="System.Web.Http, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.WebApi.Core.5.2.7\lib\net45\System.Web.Http.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
[32m+[m[32m    <Reference Include="System.Web.Http.Cors, Version=5.2.7.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, processorArchitecture=MSIL">[m
[32m+[m[32m      <HintPath>..\packages\Microsoft.AspNet.WebApi.Cors.5.2.7\lib\net45\System.Web.Http.Cors.dll</HintPath>[m
[32m+[m[32m    </Reference>[m
     <Reference Include="System.Xml.Linq" />[m
     <Reference Include="System.Data.DataSetExtensions" />[m
     <Reference Include="Microsoft.CSharp" />[m
[1mdiff --git a/PurpleRain.Services/packages.config b/PurpleRain.Services/packages.config[m
[1mindex b5bf29b..d12d14b 100644[m
[1m--- a/PurpleRain.Services/packages.config[m
[1m+++ b/PurpleRain.Services/packages.config[m
[36m@@ -1,6 +1,14 @@[m
 ﻿<?xml version="1.0" encoding="utf-8"?>[m
 <packages>[m
   <package id="EntityFramework" version="6.1.0" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.Cors" version="5.2.7" targetFramework="net472" />[m
   <package id="Microsoft.AspNet.Identity.Core" version="2.2.2" targetFramework="net472" />[m
   <package id="Microsoft.AspNet.Identity.EntityFramework" version="2.2.2" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.WebApi.Client" version="5.2.7" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.WebApi.Core" version="5.2.7" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.AspNet.WebApi.Cors" version="5.2.7" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.Owin" version="4.0.1" targetFramework="net472" />[m
[32m+[m[32m  <package id="Microsoft.Owin.Cors" version="4.0.1" targetFramework="net472" />[m
[32m+[m[32m  <package id="Newtonsoft.Json" version="6.0.4" targetFramework="net472" />[m
[32m+[m[32m  <package id="Owin" version="1.0" targetFramework="net472" />[m
 </packages>[m
\ No newline at end of file[m
[1mdiff --git a/PurpleRain.WebAPI/App_Start/SwaggerConfig.cs b/PurpleRain.WebAPI/App_Start/SwaggerConfig.cs[m
[1mnew file mode 100644[m
[1mindex 0000000..27e5850[m
[1m--- /dev/null[m
[1m+++ b/PurpleRain.WebAPI/App_Start/SwaggerConfig.cs[m
[36m@@ -0,0 +1,332 @@[m
[32m+[m[32musing System.Web.Http;[m
[32m+[m[32musing WebActivatorEx;[m
[32m+[m[32musing PurpleRain.WebAPI;[m
[32m+[m[32musing Swashbuckle.Application;[m
[32m+[m[32musing Swashbuckle.Swagger;[m
[32m+[m[32musing System.Web.Http.Description;[m
[32m+[m[32musing System.Linq;[m
[32m+[m[32musing System.Web.Http.Filters;[m
[32m+[m[32musing System.Collections.Generic;[m
[32m+[m
[32m+[m[32m[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")][m
[32m+[m
[32m+[m[32mnamespace PurpleRain.WebAPI[m
[32m+[m[32m{[m
[32m+[m[32m    /// <summary>[m
[32m+[m[32m    /// Document filter for adding Authorization header in Swashbuckle / Swagger.[m
[32m+[m[32m    /// </summary>[m
[32m+[m[32m    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter[m
[32m+[m[32m    {[m
[32m+[m[32m        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)[m
[32m+[m[32m        {[m
[32m+[m[32m            var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline();[m
[32m+[m[32m            var isAuthorized = filterPipeline[m
[32m+[m[32m                .Select(filterInfo => filterInfo.Instance)[m
[32m+[m[32m                .Any(filter => filter is IAuthorizationFilter);[m
[32m+[m
[32m+[m[32m            var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();[m
[32m+[m
[32m+[m[32m            if (!isAuthorized || allowAnonymous) return;[m
[32m+[m
[32m+[m[32m            if (operation.parameters == null) operation.parameters = new List<Parameter>();[m
[32m+[m
[32m+[m[32m            operation.parameters.Add(new Parameter[m
[32m+[m[32m            {[m
[32m+[m[32m                name = "Authorization",[m
[32m+[m[32m                @in = "header",[m
[32m+[m[32m                description = "from /token endpoint",[m
[32m+[m[32m                required = true,[m
[32m+[m[32m                type = "string"[m
[32m+[m[32m            });[m
[32m+[m[32m        }[m
[32m+[m[32m    }[m
[32m+[m
[32m+[m[32m    /// <summary>[m
[32m+[m[32m    /// Document filter for adding OAuth Token endpoint documentation in Swashbuckle / Swagger.[m
[32m+[m[32m    /// Swagger normally won't find it - the /token endpoint - due to it being programmatically generated.[m
[32m+[m[32m    /// </summary>[m
[32m+[m[32m    class AuthTokenEndpointOperation : IDocumentFilter[m
[32m+[m[32m    {[m
[32m+[m[32m        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)[m
[32m+[m[32m        {[m
[32m+[m[32m            swaggerDoc.paths.Add("/token", new PathItem[m
[32m+[m[32m  