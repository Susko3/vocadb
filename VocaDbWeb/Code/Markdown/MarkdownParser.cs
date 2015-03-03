﻿using System.Runtime.Caching;
using System.Web;
using MarkdownSharp;
using VocaDb.Model.Domain.Caching;
using VocaDb.Model.Helpers;

namespace VocaDb.Web.Code.Markdown {

	/// <summary>
	/// Caching Markdown parser
	/// </summary>
	public class MarkdownParser {

		private static string TranformMarkdown(string text) {

			if (string.IsNullOrEmpty(text))
				return text;

			// StrictBoldItalic is needed because otherwise links with underscores won't work (links are more common on VDB).
			// These settings roughtly correspond to GitHub-flavored Markdown (https://help.github.com/articles/github-flavored-markdown)
			return new MarkdownSharp.Markdown(new MarkdownOptions { AutoHyperlink = true, AutoNewLines = true, StrictBoldItalic = true }).Transform(HttpUtility.HtmlEncode(text));

		}

		private readonly ObjectCache cache;

		public MarkdownParser(ObjectCache cache) {
			this.cache = cache;
		}

		/// <summary>
		/// Transforms a block of text with Markdown. The input will be sanitized. The result will be cached.
		/// </summary>
		/// <param name="markdownText">Markdown text to be transformed. HTML will be encoded.</param>
		/// <returns>Markdown-transformed text. This will include HTML.</returns>
		public string GetHtml(string markdownText) {
			
			if (string.IsNullOrEmpty(markdownText))
				return markdownText;

			var key = string.Format("MarkdownParser.Html_{0}", markdownText);
			return cache.GetOrInsert(key, CachePolicy.Never(), () => TranformMarkdown(markdownText));

		}

		public string GetPlainText(string markdownText) {
			
			if (string.IsNullOrEmpty(markdownText))
				return markdownText;

			return HtmlHelperFunctions.StripHtml(GetHtml(markdownText));

		}

	}

}