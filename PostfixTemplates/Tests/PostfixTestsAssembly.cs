﻿using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using JetBrains.Application;
using JetBrains.ReSharper.PostfixTemplates;
using JetBrains.Threading;
using NUnit.Framework;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.TestFramework;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework.Application.Zones;
// ReSharper disable CheckNamespace

#pragma warning disable 618
[assembly: TestDataPathBase(@".\Data\Completion")]
#pragma warning restore 618

[ZoneDefinition]
public class IPostfixTestEnvironmentZone : ITestsZone, IRequire<PsiFeatureTestZone>
{
}

[SetUpFixture]
public class ReSharperTestEnvironmentAssembly : ExtensionTestEnvironmentAssembly<IPostfixTestEnvironmentZone>
{
  //[NotNull]
  //private static IEnumerable<Assembly> GetAssembliesToLoad()
  //{
  //  yield return typeof(PostfixTemplatesManager<>).Assembly;
  //  yield return Assembly.GetExecutingAssembly();
  //}
  //
  //public override void SetUp()
  //{
  //  base.SetUp();
  //
  //  ReentrancyGuard.Current.Execute("LoadAssemblies", () => {
  //    var assemblyManager = Shell.Instance.GetComponent<AssemblyManager>();
  //    assemblyManager.LoadAssemblies(GetType().Name, GetAssembliesToLoad());
  //  });
  //}
  //
  //public override void TearDown()
  //{
  //  ReentrancyGuard.Current.Execute("UnloadAssemblies", () => {
  //    var assemblyManager = Shell.Instance.GetComponent<AssemblyManager>();
  //    assemblyManager.UnloadAssemblies(GetType().Name, GetAssembliesToLoad());
  //  });
  //
  //  base.TearDown();
  //}
}