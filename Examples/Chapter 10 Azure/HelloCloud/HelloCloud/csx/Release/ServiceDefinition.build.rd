<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="HelloCloud" generation="1" functional="0" release="0" Id="769aa587-cde2-4443-9cbb-1e43cdf9a4d3" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="HelloCloudGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="HelloAzureWebApp:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/HelloCloud/HelloCloudGroup/LB:HelloAzureWebApp:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="HelloAzureWebApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/HelloCloud/HelloCloudGroup/MapHelloAzureWebApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="HelloAzureWebAppInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/HelloCloud/HelloCloudGroup/MapHelloAzureWebAppInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:HelloAzureWebApp:Endpoint1">
          <toPorts>
            <inPortMoniker name="/HelloCloud/HelloCloudGroup/HelloAzureWebApp/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapHelloAzureWebApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/HelloCloud/HelloCloudGroup/HelloAzureWebApp/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapHelloAzureWebAppInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/HelloCloud/HelloCloudGroup/HelloAzureWebAppInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="HelloAzureWebApp" generation="1" functional="0" release="0" software="E:\Work\Introducing .NET 4.5\Projects\HelloCloud\HelloCloud\csx\Release\roles\HelloAzureWebApp" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;HelloAzureWebApp&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;HelloAzureWebApp&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/HelloCloud/HelloCloudGroup/HelloAzureWebAppInstances" />
            <sCSPolicyFaultDomainMoniker name="/HelloCloud/HelloCloudGroup/HelloAzureWebAppFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="HelloAzureWebAppFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="HelloAzureWebAppInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="a9e56230-903b-4db7-b3a8-60b224c52e43" ref="Microsoft.RedDog.Contract\ServiceContract\HelloCloudContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="45f0b47a-4e84-45d6-a9d8-fe227a4d0c15" ref="Microsoft.RedDog.Contract\Interface\HelloAzureWebApp:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/HelloCloud/HelloCloudGroup/HelloAzureWebApp:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>