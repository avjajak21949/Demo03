using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Demo03.Models
{
    public class Meeting
    {
        [Key]
        public int MeetingID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Meeting Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Meeting Link")]
        public string MeetingLink { get; set; }  // Google Meet or other platform link

        [Required]
        public string HostUserId { get; set; }  // Teacher who created the meeting

        [ForeignKey("HostUserId")]
        public IdentityUser Host { get; set; }

        [Required]
        public int ClassID { get; set; }  // Associated class

        [ForeignKey("ClassID")]
        public Class Class { get; set; }

        [StringLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
} 