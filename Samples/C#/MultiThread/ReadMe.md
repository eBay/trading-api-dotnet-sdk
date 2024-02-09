MultiThread
--------------------

These instructions describe how to build and run the **MultiThread** test. This test is written in C#.NET and runs **AddItem/GetItem/ReviseItem** calls in the eBay Production environment using multiple threads.

### How to Build and Run the Sample

1.  Open **MultiThread.csproj** in your version of Microsoft Visual Studio.
2.  Edit the **MultiThread/App.config** file. Add values in the **value** attribute for the lines with a **key** attribute of **token**, and **soapurl**. To retrieve the items, **soapurl** and the credentials must be valid for the Production environment.
    
    **Note:** Be sure to make the changes to **App.config** in the top-level **MultiThread** directory if you want the changes to persist each time you build the sample. The files in the **bin** (executable) directory are overwritten with each build.
    
3.  Build the solution in your version: **Build > Build Solution**.
4.  Run the solution: **Debug > Start Without Debugging**.
5.  In the sample's dialog box, choose a number of threads in **Num Threads**.
6.  Choose a number of calls per thread you want in **Num Calls**. The total number of calls made will be the value of **Num Calls** times the value of **Num Threads**.
7.  Enter a valid Production token, if you did not enter the token in **App.config**.
8.  Click **Start**.
9.  Check for details of the test run in **bin/log.txt**. They should look similar to this:
```
    [12/1/2006 11:45:16 AM, Informational]
    Total     Setup     Network   Server    Finish    Start Time          
    
    [12/1/2006 11:45:16 AM, Informational]
    ======================================================================
    
    [12/1/2006 11:45:16 AM, Informational]
    8703      7140      635       286       640       2006-12-01 11:45:04.920  
    
    [12/1/2006 11:45:16 AM, Informational]
    359       0         90        253       15        2006-12-01 11:45:13.638  
    
    [12/1/2006 11:45:16 AM, Informational]
    484       0         265       203       15        2006-12-01 11:45:13.998  
    .
    .
    .
```