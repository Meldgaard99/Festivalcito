﻿using System;
using Festivalcito.Shared.Classes;
using System.Net.Http.Json;

namespace Festivalcito.Client.Services.PersonAssignmentServicesFolder
{
    public class PersonAssignmentService : IPersonAssignmentService
    {
        private readonly HttpClient httpClient;

        public PersonAssignmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<int> CreatePersonAssignment(PersonAssignment ReadPersonAssignment)
        {
            var response = await httpClient.PostAsJsonAsync<PersonAssignment>("api/assigned/", ReadPersonAssignment);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<PersonAssignment> ReadPersonAssignment(int ReadPersonAssignmentId)
        {
            return (await httpClient.GetFromJsonAsync<PersonAssignment>("api/assigned/" + ReadPersonAssignmentId))!;
        }

        public async Task<PersonAssignment[]?> ReadAllPersonAssignments()
        {
            return await httpClient.GetFromJsonAsync<PersonAssignment[]>("api/assigned/");
        }


        public async Task<int> DeletePersonAssignment(int ReadPersonAssignmentId)
        {
            var response = await httpClient.DeleteAsync("api/assigned/" + ReadPersonAssignmentId);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }



    }
}

