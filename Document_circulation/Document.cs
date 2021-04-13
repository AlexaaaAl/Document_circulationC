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
        private string path { get; set; }
        private string document { get; set; }
        private string id_sender { get; set; }
        private string id_recipient { get; set; }
        private string out_number { get; set; }
        private string comments { get; set; }
        private string status { get; set; }
        private string document_type { get; set; }
        private DateTime date { get; set; }
        private DateTime date_added { get; set; }
        public Document(int id_document, int number,/*string path, string document,*/ string id_sender, string id_recipient,
                   string out_number, string comments, /*DateTime date,*/ DateTime date_added, string status, string document_type)
        {
            this.id_document = id_document;
            this.number = number;
            this.id_sender = id_sender;
            this.id_recipient = id_recipient;
            this.out_number = out_number;
            this.comments = comments;
            this.date_added = date_added;
            /*this.date = date;*/
            this.status = status;
            this.document_type = document_type;
        }
    }
}
