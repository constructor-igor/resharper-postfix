﻿using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.ReSharper.ControlFlow.PostfixCompletion.LookupItems;
using JetBrains.ReSharper.Feature.Services.Lookup;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.CSharp.Util;

namespace JetBrains.ReSharper.ControlFlow.PostfixCompletion.TemplateProviders
{
  [PostfixTemplate(
    templateName: "await",
    description: "Awaits expressions of 'Task' type",
    example: "await expr")]
  public class AwaitExpressionTemplate : IPostfixTemplate {
    public ILookupItem CreateItems(PostfixTemplateContext context) {
      var expressionContext = context.InnerExpression;
      var function = context.ContainingFunction;
      if (function == null) return null;

      if (!context.ForceMode) {
        if (!function.IsAsync) return null;

        var expressionType = expressionContext.Type;
        if (!expressionType.IsUnknown) {
          if (!(expressionType.IsTask() ||
                expressionType.IsGenericTask())) return null;
        }
      }

      // check expression is not already awaited
      var expression = (context.PostfixReferenceNode as IReferenceExpression);
      var awaitExpression = AwaitExpressionNavigator.GetByTask(
        expression.GetContainingParenthesizedExpression() as IUnaryExpression);

      if (awaitExpression != null) return null;

      return new AwaitItem(expressionContext);
    }

    private sealed class AwaitItem : ExpressionPostfixLookupItem<IAwaitExpression> {
      public AwaitItem([NotNull] PrefixExpressionContext context) : base("await", context) { }

      protected override IAwaitExpression CreateExpression(CSharpElementFactory factory,
                                                           ICSharpExpression expression) {
        return (IAwaitExpression) factory.CreateExpression("await $0", expression);
      }
    }
  }
}