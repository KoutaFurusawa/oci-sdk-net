using System;
using System.Collections.Generic;
using System.Text;

namespace OCISDK.Core.LoadBalancer.Model
{
    /// <summary>
    /// An object that represents an action to apply to a listener.
    /// </summary>
    // TODO: Cannot parse JSON with multiple subtype structures.
    public class RuleDetails
    {
        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// A header name that conforms to RFC 7230.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// A header value that conforms to RFC 7230.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// A string to prepend to the header value. The resulting header value must conform to RFC 7230.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// A string to append to the header value. The resulting header value must conform to RFC 7230.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// The list of HTTP methods allowed for this listener.
        /// By default, you can specify only the standard HTTP methods defined in the HTTP Method Registry. 
        /// You can also see a list of supported standard HTTP methods in the Load Balancing service documentation at Managing Rule Sets.
        /// Your backend application must be able to handle the methods specified in this list.
        /// The list of HTTP methods is extensible. If you need to configure custom HTTP methods, contact My Oracle Support to remove the restriction for your tenancy.
        /// </summary>
        public List<string> AllowedMethods { get; set; }

        /// <summary>
        /// The HTTP status code to return when the requested HTTP method is not in the list of allowed methods. 
        /// The associated status line returned with the code is mapped from the standard HTTP specification. The default value is 405 (Method Not Allowed).
        /// </summary>
        public int? StatusCode { get; set; }

        /// <summary>
        /// A condition to apply to an access control rule.
        /// </summary>
        public List<RuleCondition> Conditions { get; set; }

        /// <summary>
        /// A brief description of the access control rule. Avoid entering confidential information.
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// An object that represents the action of adding a header to a request. This rule applies only to HTTP listeners.
    /// </summary>
    public class AddHttpRequestHeaderRule
    {
        /// <summary>
        /// Required value: ADD_HTTP_REQUEST_HEADER
        /// <para>Required: yes</para>
        /// </summary>
        public readonly string Action = "ADD_HTTP_REQUEST_HEADER";

        /// <summary>
        /// A header name that conforms to RFC 7230.
        /// <para>Required: yes</para>
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// A header value that conforms to RFC 7230.
        /// <para>Required: yes</para>
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// An object that represents the action of modifying a request header value. This rule applies only to HTTP listeners.
    /// 
    /// This rule adds a prefix, a suffix, or both to the header value.
    /// </summary>
    public class ExtendHttpRequestHeaderValueRule
    {
        /// <summary>
        /// Required value: EXTEND_HTTP_REQUEST_HEADER_VALUE
        /// <para>Required: yes</para>
        /// </summary>
        public readonly string Action = "EXTEND_HTTP_REQUEST_HEADER_VALUE";

        /// <summary>
        /// A header name that conforms to RFC 7230.
        /// <para>Required: yes</para>
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// A string to prepend to the header value. The resulting header value must conform to RFC 7230.
        /// <para>Required: no</para>
        /// </summary>
        public string Prefix { get; set;}

        /// <summary>
        /// A string to append to the header value. The resulting header value must conform to RFC 7230.
        /// <para>Required: no</para>
        /// </summary>
        public string Suffix { get; set; }
    }

    /// <summary>
    /// An object that represents the action of removing a header from a request. This rule applies only to HTTP listeners.
    /// 
    /// If the same header appears more than once in the request, the load balancer removes all occurances of the specified header.
    /// </summary>
    public class RemoveHttpRequestHeaderRule
    {
        /// <summary>
        /// Required value: REMOVE_HTTP_REQUEST_HEADER
        /// <para>Required: yes</para>
        /// </summary>
        public readonly string Action = "REMOVE_HTTP_REQUEST_HEADER";

        /// <summary>
        /// A header name that conforms to RFC 7230.
        /// <para>Required: yes</para>
        /// </summary>
        public string Header { get; set; }
    }

    /// <summary>
    /// An object that represents the action of adding a header to a response. This rule applies only to HTTP listeners.
    /// </summary>
    public class AddHttpResponseHeaderRule
    {
        /// <summary>
        /// Required value: ADD_HTTP_RESPONSE_HEADER
        /// <para>Required: yes</para>
        /// </summary>
        public readonly string Action = "ADD_HTTP_RESPONSE_HEADER";

        /// <summary>
        /// A header name that conforms to RFC 7230.
        /// <para>Required: yes</para>
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// A header value that conforms to RFC 7230.
        /// <para>Required: yes</para>
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// An object that represents the action of modifying a response header value. This rule applies only to HTTP listeners.
    /// 
    /// This rule adds a prefix, a suffix, or both to the header value.
    /// </summary>
    public class ExtendHttpResponseHeaderValueRule
    {
        /// <summary>
        /// Required value: EXTEND_HTTP_RESPONSE_HEADER_VALUE
        /// <para>Required: yes</para>
        /// </summary>
        public readonly string Action = "EXTEND_HTTP_RESPONSE_HEADER_VALUE";

        /// <summary>
        /// A header name that conforms to RFC 7230.
        /// <para>Required: yes</para>
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// A string to prepend to the header value. The resulting header value must conform to RFC 7230.
        /// <para>Required: no</para>
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// A string to append to the header value. The resulting header value must conform to RFC 7230.
        /// <para>Required: no</para>
        /// </summary>
        public string Suffix { get; set; }
    }

    /// <summary>
    /// An object that represents the action of removing a header from a response. This rule applies only to HTTP listeners.
    /// 
    /// If the same header appears more than once in the response, the load balancer removes all occurances of the specified header.
    /// </summary>
    public class RemoveHttpResponseHeaderRule
    {
        /// <summary>
        /// Required value: REMOVE_HTTP_RESPONSE_HEADER
        /// <para>Required: yes</para>
        /// </summary>
        public readonly string Action = "REMOVE_HTTP_RESPONSE_HEADER";

        /// <summary>
        /// A header name that conforms to RFC 7230.
        /// <para>Required: yes</para>
        /// </summary>
        public string Header { get; set; }
    }

    /// <summary>
    /// An object that represents the action of returning a specified response code when the requested HTTP method is not in the list of allowed methods for the listener. 
    /// The load balancer does not forward a disallowed request to the back end servers. The default response code is 405 Method Not Allowed.
    /// 
    /// If you set the response code to 405 or leave it blank, the system adds an "allow" response header that contains a list of the allowed methods for the listener. 
    /// If you set the response code to anything other than 405 (or blank), the system does not add the "allow" response header with a list of allowed methods.
    /// 
    /// This rule applies only to HTTP listeners. No more than one ControlAccessUsingHttpMethodsRule object can be present in a given listener.
    /// </summary>
    public class ControlAccessUsingHttpMethodsRule
    {
        /// <summary>
        /// Required value: CONTROL_ACCESS_USING_HTTP_METHODS
        /// <para>Required: yes</para>
        /// </summary>
        public readonly string Action = "CONTROL_ACCESS_USING_HTTP_METHODS";

        /// <summary>
        /// The list of HTTP methods allowed for this listener.
        /// <para>Required: yes</para>
        /// </summary>
        public List<string> AllowedMethods { get; set; }

        /// <summary>
        /// The HTTP status code to return when the requested HTTP method is not in the list of allowed methods. 
        /// The associated status line returned with the code is mapped from the standard HTTP specification. 
        /// The default value is 405 (Method Not Allowed).
        /// <para>Required: no</para>
        /// </summary>
        public int? StatusCode { get; set; }
    }

    /// <summary>
    /// An object that represents the action of configuring an access control rule. 
    /// Access control rules permit access to application resources based on user-specified match conditions. 
    /// This rule applies only to HTTP listeners.
    /// </summary>
    public class AllowRule
    {
        /// <summary>
        /// Required value: ALLOW
        /// <para>Required: yes</para>
        /// </summary>
        public readonly string Action = "ALLOW";

        /// <summary>
        /// <para>Required: yes</para>
        /// </summary>
        public List<RuleCondition> Conditions { get; set; }

        /// <summary>
        /// A brief description of the access control rule. Avoid entering confidential information.
        /// <para>Required: no</para>
        /// </summary>
        public string Description { get; set; }
    }
}
