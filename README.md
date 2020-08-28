<h1>Projects</h1>
The <b>Project management application </b> is a multilayered <b>Asp .Net Core application</b> that uses different programming patterns to basically do CRUD operations with projects, and also deal with managers and their relationship with projects. Architecture is based on concept of <b>clean architecture</b> combined with layered pattern architecture. Components within the layered architecture pattern are organized into horizontal layers, each layer performing a specific role within the application.<br/>
<br/>
There are three different layers:
<ul>
	<li>Application layer</li>
  <li>Service layer</li>
  <li>Data access layer</li>
</ul>

Each layer communicates only with a layer below. All interactions between the components of each layer, with the rest of the system is defined via interfaces.
<b>Data access layer</b> is used to communicate with a database, it is developed with <b>repository pattern</b> in <b>.NET Core Entity Framework</b>, using the code first approach. <b>Service layer</b> communicates with data access layer and has important atomic system functionalities exposed to the layer above, while encapsulating the important business logic.
<b>MVC Application layer</b> communicates with service layer and with controllers and views does the representational part of the application.

<ul>
	Programming languages:
	<i><li>C#</li></i>
	<i><li>Javascript</li></i>
	<i><li>Linq</li></i>
</ul>
<ul>
Technologies: 
	<i><li>Asp.Net Core</li></i>
	<i><li>Entity framework</li></i>
	<i><li>Razor View pages</li></i>
</ul>
<ul>
IDE: 
	<i><li>Visual Studio</li></i>
	<i><li>Microsoft SQL Server Management Studio</li></i>
</ul>
