﻿namespace DemansAppWeb.Helper.DTO.Companions
{
    public class updateCompanionsRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Sex { get; set; }

    }
}