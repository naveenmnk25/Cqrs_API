using System;

namespace CleanArchitecture.Application.Dto
{
    public class WorkItemDto
    {
        public WorkItemDto()
        {

        }
        public int WorkItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WorkItemTypeId { get; set; }
        public string WorkItemType { get; set; }
        public int PriorityId { get; set; }
        public string Priority { get; set; }
        public int SeverityId { get; set; }
        public string Severity { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public int ParentWorkItemId { get; set; }
        public string ParentWorkItem { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //  public int AssignedToId { get; set; }
        //  public string AssignedTo { get; set; }
    }
}
