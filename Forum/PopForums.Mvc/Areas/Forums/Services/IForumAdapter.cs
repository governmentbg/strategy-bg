﻿using Microsoft.AspNetCore.Mvc;
using PopForums.Models;

namespace PopForums.Mvc.Areas.Forums.Services
{
	/// <summary>
	/// Enables alternate views and processing to individual forums.
	/// </summary>
	/// <remarks>
	/// Concrete implementations of this interface can be specified in the admin forum properties. The
	/// Index, Topic and PostLink methods of the forum controller will alter their behavior based on 
	/// the implementation. See individual members for details.
	/// </remarks>
	public interface IForumAdapter
	{
		/// <summary>
		/// This method allows you to change the view and model generated by the Index method of the ForumController by setting
		/// the properties on the adapter.
		/// </summary>
		/// <param name="controller">Instance of the controller calling the adapter.</param>
		/// <param name="forumTopicContainer">The composed ForumTopicContainer created by the Index method of the ForumController.</param>
		void AdaptForum(Controller controller, ForumTopicContainer forumTopicContainer);

		/// <summary>
		/// This method allows you to change the view and model generated by the Topic method of the ForumController by setting
		/// the properties on the adapter.
		/// </summary>
		/// <param name="controller">Instance of the controller calling the adapter.</param>
		/// <param name="topicContainer">The composed TopicContainer created by the Topic method of the ForumController.</param>
		void AdaptTopic(Controller controller, TopicContainer topicContainer);

		/// <summary>
		/// This method allows you to override the behavior of the ForumController's PostLink 
		/// method. Use this if you need the links to redirect to some other location, otherwise
		/// return null.
		/// </summary>
		/// <param name="controller">Instance of the controller calling the adapter.</param>
		/// <param name="post">The post associated with the id parameter of the PostLink method.</param>
		/// <param name="topic">The topic associated with the post.</param>
		/// <param name="forum">The forum associated with the topic.</param>
		/// <returns></returns>
		RedirectResult AdaptPostLink(Controller controller, Post post, Topic topic, Forum forum);

		/// <summary>
		/// Set this in the adapter for alternate views from the AdaptForum and AdaptTopic methods.
		/// </summary>
		string ViewName { get; }

		/// <summary>
		/// Set this in the adapter for alternate an alternate model from the AdaptForum and AdaptTopic methods.
		/// </summary>
		object Model { get; }

		/// <summary>
		/// To allow the controller to mark the topic as read, set this to true, otherwise, false.
		/// </summary>
		bool MarkViewedTopicRead { get; }
	}
}
