using Domain.Entities.Lookups;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Documents
{
    public class DivorceDoc : DocumentBase
    {
        public RequesterName Name { get; set; }
        public NID NID { get; set; }
        public string SpouseFullName { get; set; }
        public int RelationId { get; set; }
        public Relation Relation { get; set; }
    }
}
