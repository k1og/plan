using FluentNHibernate.Mapping;
using PlanManagerLib.models;

namespace UI.Plan.Web.NH.Mappings
{
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Id(self => self.Uid);
            Map(self => self.Title);
            Map(self => self.Description).Length(400);
            Map(evt => evt.StartDate).Nullable();
            Map(evt => evt.EndDate).Nullable();
            Map(self => self.Place);
        }
    }
}