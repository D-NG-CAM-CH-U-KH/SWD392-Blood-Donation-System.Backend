﻿namespace SWD392_BloodDonationSystem.Constants;

public class APIEndpointsConstant
{
    public const string ROOT_ENDPOINT = "/api";
    public const string API_VERSION = "/v1";
    public const string API_ENDPOINT = ROOT_ENDPOINT + API_VERSION;
    
    public static class AuthEndpoints
    {
        public const string AUTH_ENDPOINT = API_ENDPOINT + "/auth";
        public const string LOGIN_ENDPOINT = AUTH_ENDPOINT + "/login";
    }
    
    public static class AccountEndpoints
    {
        public const string ACCOUNT_ENDPOINT = API_ENDPOINT + "/account";
        public const string GET_ACCOUNT_ENDPOINT = ACCOUNT_ENDPOINT;
        public const string GET_CURRENT_ACCOUNT_ENDPOINT = ACCOUNT_ENDPOINT + "/current";
        public const string GET_MANY_ACCOUNTS_ENDPOINT = ACCOUNT_ENDPOINT + "/many";
        public const string GET_ACCOUNT_BY_ID_ENDPOINT = ACCOUNT_ENDPOINT + "/{id}";
        public const string CREATE_ACCOUNT_ENDPOINT = ACCOUNT_ENDPOINT;
        public const string UPDATE_ACCOUNT_ENDPOINT = ACCOUNT_ENDPOINT + "/{id}";
        public const string DELETE_ACCOUNT_ENDPOINT = ACCOUNT_ENDPOINT + "/{id}";
    }

    public static class DateEndpoints
    {
        public const string DATE_ENDPOINT = API_ENDPOINT + "/date";
    }
}