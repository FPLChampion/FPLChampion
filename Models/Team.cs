using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mvc.Models {
    public class Team {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int teamid { get; set; }
        public List<CurrentEventFixture> current_event_fixture { get; set; }
        public List<NextEventFixture> next_event_fixture { get; set; }
        public string name { get; set; }
        public int code { get; set; }
        public string short_name { get; set; }
        public bool unavailable { get; set; }
        public int strength { get; set; }
        public int position { get; set; }
        public int played { get; set; }
        public int win { get; set; }
        public int loss { get; set; }
        public int draw { get; set; }
        public int points { get; set; }
        public object form { get; set; }
        public string link_url { get; set; }
        public int strength_overall_home { get; set; }
        public int strength_overall_away { get; set; }
        public int strength_attack_home { get; set; }
        public int strength_attack_away { get; set; }
        public int strength_defence_home { get; set; }
        public int strength_defence_away { get; set; }
        public int team_division { get; set; }

    }

    public class CurrentEventFixture
    {
        public bool is_home { get; set; }
        public int day { get; set; }
        public int event_day { get; set; }
        public int month { get; set; }
        public int fixtureid { get; set; }
        public int opponent { get; set; }
    }

    public class NextEventFixture
    {
        public bool is_home { get; set; }
        public int day { get; set; }
        public int event_day { get; set; }
        public int month { get; set; }
        public int fixtureid { get; set; }
        public int opponent { get; set; }
    }
}