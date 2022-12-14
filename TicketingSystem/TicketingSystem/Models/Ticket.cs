using System.ComponentModel.DataAnnotations;
namespace TicketingSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a sprint number.")]
        public string SprintNum { get; set; }

        [Required(ErrorMessage = "Please enter a point value.")]
        [Range(1,5)]
        public string Point { get; set; }
        [Required(ErrorMessage = "Please enter a status.")]
        public string StatusId { get; set; }
        public Status? Status { get; set; }
    }
}
