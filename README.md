# WebAppWithDatabaseDemo
Sample ASP.NET Core MVC app with database, UI tests (Selenium) and ARM template for demoing CI-CD pipelines using Azure DevOps Pipelines (previously VSTS).

</br>

<table>
  <tr>
    <td>Build status</td>
    <td>Release status - dev</td> 
    <td>Release status - test</td>  
    <td>Release status - prod</td>
  </tr>
  <tr>
    <td>
<img src="https://houssemdellai.visualstudio.com/WebAppWithDatabaseDemo/_apis/build/status/WebAppWithDatabase-CI-mutiphase?branchName=master"/>
    </td>
    <td>
<img src="https://houssemdellai.vsrm.visualstudio.com/_apis/public/Release/badge/7ac88337-9f15-48dd-ab33-a60c7a26e4a5/4/6"/>
  </td>
    <td>
<img src="https://houssemdellai.vsrm.visualstudio.com/_apis/public/Release/badge/7ac88337-9f15-48dd-ab33-a60c7a26e4a5/4/9"/>
    </td>
    <td>
<img src="https://houssemdellai.vsrm.visualstudio.com/_apis/public/Release/badge/7ac88337-9f15-48dd-ab33-a60c7a26e4a5/4/10"/>
  </td>
  </tr>
  </table>
  
  </br>
  
  <a href="http://armviz.io/#/?load=https://raw.githubusercontent.com/HoussemDellai/WebAppWithDatabaseDemo/master/AzureResourceGroupDeployment/WebSiteSQLDatabase.json" target="_blank">
  <img src="http://armviz.io/visualizebutton.png"/>
</a>

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FHoussemDellai%2FWebAppWithDatabaseDemo%2Fmaster%2FAzureResourceGroupDeployment%2FWebSiteSQLDatabase.json" rel="nofollow">
    <img src="http://azuredeploy.net/deploybutton.png" style="max-width:100%;">
</a>

</br>

The complete demo is available on youtube on this link:  
https://www.youtube.com/watch?v=X-RNXvI5_Ek&list=PLpbcUe4chE7_J_la3FlruUfAN1ec7H_bR&index=24    

<a href="https://www.youtube.com/watch?v=X-RNXvI5_Ek&list=PLpbcUe4chE7_J_la3FlruUfAN1ec7H_bR&index=24"><image src="https://github.com/HoussemDellai/WebAppWithDatabaseDemo/blob/master/docs/Youtube-YAML-CI-CD-Pipelines.jpg?raw=true"/>
</a>

Another (old) demo was also done using Classic Designer:  
https://www.youtube.com/watch?v=uVne2HXkWXI&list=PLpbcUe4chE78FEvDjD9zfzSGvsdkvkkrj&index=1

<a href="https://www.youtube.com/watch?v=uVne2HXkWXI&list=PLpbcUe4chE78FEvDjD9zfzSGvsdkvkkrj&index=1"><image src="https://github.com/HoussemDellai/WebAppWithDatabaseDemo/blob/master/docs/Youtube-Classic-CI-CD-Pipelines.jpg?raw=true"/>
</a>

Pipelines flows are sketched in this picture:
<image src="https://github.com/HoussemDellai/WebAppWithDatabaseDemo/blob/master/docs/CI-CD-Pipelines.jpg?raw=true"/>