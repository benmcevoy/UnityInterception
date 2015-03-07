# UnityInterception
example getting unity interception working using attributes on your business classes

unity does not use a weaver AFAIK, dynamic and a load of reflection.emit

https://msdn.microsoft.com/en-us/library/dn178466%28v=pandp.30%29.aspx

https://unity.codeplex.com/

https://unity.codeplex.com/SourceControl/latest#source/Unity.Interception/Src/Interceptors/InstanceInterceptors/InterfaceInterception/InterfaceMethodOverride.cs

You can only intercept methods. Interceptors are chained and I should have implemented the Order (control execution order) property on that LogAttribute, but meh.
