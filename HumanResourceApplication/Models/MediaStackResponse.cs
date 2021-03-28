using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourceApplication.Models
{
    public class MediaStackResponse
    {
        public MediaPagination Pagination { get; set; }
        public IList<MediaData> Data { get; set; }
    }

    public class MediaData
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Source { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Publish_at { get; set; }
    }

    public class MediaPagination
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }
}
