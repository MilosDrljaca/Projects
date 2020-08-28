<h1>Projects - Project management application</h1>

Architecture is based on concept of <b>clean architecture</b> combined with layered pattern architecture. Components within the layered architecture pattern are organized into horizontal layers, each layer performing a specific role within the application.<br/>

There are three different layers:
<ul>
	<li>Application layer</li>
  <li>Service layer</li>
  <li>Data access layer</li>
</ul>

Each layer communicates only with a layer below. All interactions between the components of each layer, with the rest of the system is defined via interfaces.
<b>Data access layer</b> is used to communicate with a database, it is developed with <b>repository pattern</b> in <b>.NET Core Entity Framework</b>, using the code first approach. <b>Service layer</b> communicates with data access layer and has important atomic system functionalities exposed to the layer above, while encapsulating the important business logic.
<b>MVC Application layer</b> communicates with service layer and with controllers and views does the representational part of the application.
