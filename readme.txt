The code contained in this project was built using Visual Studio 19 and it is
an ASP.NET Core MVC project. As a seasoned Java developer but someone new to
the ASP.NET Framework world, my primary consideration was to deliver a solid 
back end solution using the tried and true Repository pattern and I am happy
with the result though I did run into a hiccup with some of the unit testing
I planned on using. Comments concerning these issues surrounding the failed 
unit tests are including in the actual unit test C# files in the unit test 
sub-project. Also, while I am happy with the back end code, the front end 
leaves a lot to be desired. It works, but is far from a polished solution I
would have liked to deliver. 

To build and run this project you will need:

	Visual Studio with ASP.NET Core 3.1
	Some sort of relational database (I used SQL Server)
	Just replace the default connection string with your own.
	
Now in migrations folder, there is a file "20200630021924_InitialDbPush.cs" that
was created when I ran the "add-migration" command. But I also manually added
some additional entries to this file after the initial creation and that was 
to ensure that three rows were added to the "Categories" table since there is
no user interface in the application to support adding or modifying Categories.

Below are the three entries I made:

	migrationBuilder.InsertData(
		table: "Categories",
		columns: new[] { "CategoryType", "Description", "Limits" },
		values: new object[] { 0, "Electronics", 0 });

	migrationBuilder.InsertData(
		table: "Categories",
		columns: new[] { "CategoryType", "Description", "Limits" },
		values: new object[] { 1, "Clothing", 0 });

	migrationBuilder.InsertData(
		table: "Categories",
		columns: new[] { "CategoryType", "Description", "Limits" },
		values: new object[] { 2, "Kitchen", 0 });

This mini-project uses JavaScript very sparingly. Outside of the initial
boiler plate solution Microsoft supplies when you create a ASP.NET MVC project
(such as including bootstrap which was helpful to me as I did use bootstrap to
make the webpage a little more presentable), the only JavaScript file I included
came from "https://cdn.datatables.net/" folks and that was to use their HTML table. 

When I started this mini-project, I knew I was going to need either a tree or a
table with expandable rows to render the data in a single page web format. I felt
an expandable table would look better and the "https://cdn.datatables.net/" folks
do provide this capability by altering the class type of the table. Now I ran into 
another hiccup along the way and ended up creating my own row expander JavaScript 
file instead of using the script the Data Table authors recommend. Not sure if the
Data Table script keeps state of whether Categories rows were expanded or contracted 
during form submits, but my simple implentation does not store the state. So when
you either add or remove an Item, all Categories and their associated Items are 
expanded. But the row expander JavaScript solution I implemented does work. 

Finally, one of the requirements ask was that the data be sortable in the user 
interface and the data table does this for you. You do however need to include 
their page pagination widgets and unfortunately these widgets appear above and 
below the data table with no way to customize it. In all honesty the UI looked ugly
with them since I was also asked to render my own widgets to add new Items. So I 
purposely omitted the page pagination features of the table meaning I also lost the
default sort capabilities. Now I did expose sort APIs in the CategoriesRepository as
well as the ItemRepository classes with working unit tests to prove that they do
indeed work. But none of these sort APIs are hooked up to the UI. 

In summary, I am happy with the back end solution of this mini-project. But I know
I have plenty of work to do in order to bring my front end skills up to 2020 levels. :/