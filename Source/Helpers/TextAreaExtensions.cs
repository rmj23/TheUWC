namespace Source.Helpers
{
    //public static class TextAreaExtensions
    //{
    //    public static IHtmlString TextAreaAutoSizeFor<TModel, TProperty>(
    //        this HtmlHelper<TModel> htmlHelper,
    //        Expression<Func<TModel, TProperty>> expression,
    //        object htmlAttributes
    //    )
    //    {
    //        var model = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model;
    //        var text = model as string ?? string.Empty;
    //        int width = 55;
    //        int lines = 1;
    //        string[] arr = text.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
    //        foreach (var str in arr)
    //        {
    //            if (str.Length / width > 0)
    //            {
    //                lines += str.Length / width + (str.Length % width <= width / 2 ? 1 : 0);
    //            }
    //            else
    //            {
    //                lines++;
    //            }
    //        }
    //        var attributes = new RouteValueDictionary(htmlAttributes);
    //        attributes["style"] = string.Format("width:{0}em; height:{1}em;", width, lines);
    //        return htmlHelper.TextAreaFor(expression, attributes);
    //    }
    //}
}