using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_circulation
{
    class Document
    {
        private int id_document { get; set; }
        private int number { get; set; }
        private String path { get; set; }
        private String document { get; set; }
        private String id_sender { get; set; }
        private String id_recipient { get; set; }
        private String outline { get; set; }
        private String comments { get; set; }
        private String status { get; set; }
        private String document_type { get; set; }
        private DateTime date { get; set; }
        private DateTime date_added { get; set; }
        public Document(int id_document, int number,String id_sender, String id_recipient,
                   String outline, String comments, DateTime date, DateTime date_added, String status, String document_type)
        {
            this.id_document = id_document;
            this.number = number;
            this.id_sender = id_sender;
            this.id_recipient = id_recipient;
            this.outline = outline;
            this.comments = comments;
            this.date_added = date_added;
            this.date = date;
            this.status = status;
            this.document_type = document_type;
        }
    }
}
