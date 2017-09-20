﻿using System;
using System.Runtime.Serialization;

namespace SharedResourcesLibrary
{
    [DataContract]
    public class OAuthAuthorization
    {
        [DataMember(Name = "access_token")]
        public String AccessToken { get; set; }

        [DataMember(Name = "user_id")]
        public String UserId { get; set; }

        [DataMember(Name = "expires_in")]
        public String ExpiresIn { get; set; }
    }
}