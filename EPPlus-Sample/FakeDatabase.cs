﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlus_Sample
{
    public class FakeDatabase
    {
        private static readonly Lecture[] _lectures =
        {
            new Lecture {Id = 1, TeacherId = 10, Name = "JSON-RPC", Level = "intermediate"},
            new Lecture {Id = 2, TeacherId = 3, Name = "Zenoss", Level = "advanced"},
            new Lecture {Id = 3, TeacherId = 14, Name = "HDL Designer", Level = "basic"},
            new Lecture {Id = 4, TeacherId = 26, Name = "Pianist", Level = "basic"},
            new Lecture {Id = 5, TeacherId = 13, Name = "Java", Level = "intermediate"},
            new Lecture {Id = 6, TeacherId = 14, Name = "NFPA 101", Level = "advanced"},
            new Lecture {Id = 7, TeacherId = 29, Name = "TNS", Level = "advanced"},
            new Lecture {Id = 8, TeacherId = 18, Name = "Gas Chromatography", Level = "advanced"},
            new Lecture {Id = 9, TeacherId = 8, Name = "Whole Life", Level = "basic"},
            new Lecture {Id = 10, TeacherId = 12, Name = "osCommerce", Level = "intermediate"},
            new Lecture {Id = 11, TeacherId = 25, Name = "Turbines", Level = "advanced"},
            new Lecture {Id = 12, TeacherId = 29, Name = "EBMS", Level = "basic"},
            new Lecture {Id = 13, TeacherId = 28, Name = "RHIA", Level = "basic"},
            new Lecture {Id = 14, TeacherId = 21, Name = "DBVisualizer", Level = "basic"},
            new Lecture {Id = 15, TeacherId = 11, Name = "GSS", Level = "basic"},
            new Lecture {Id = 16, TeacherId = 26, Name = "McKesson STAR", Level = "basic"},
            new Lecture {Id = 17, TeacherId = 27, Name = "NRA", Level = "intermediate"},
            new Lecture {Id = 18, TeacherId = 22, Name = "SSPS", Level = "basic"},
            new Lecture {Id = 19, TeacherId = 8, Name = "Twitter API", Level = "basic"},
            new Lecture {Id = 20, TeacherId = 25, Name = "FTTx", Level = "advanced"},
            new Lecture {Id = 21, TeacherId = 6, Name = "Blog Marketing", Level = "intermediate"},
            new Lecture {Id = 22, TeacherId = 28, Name = "FM", Level = "intermediate"},
            new Lecture {Id = 23, TeacherId = 4, Name = "Global Business Development", Level = "intermediate"},
            new Lecture {Id = 24, TeacherId = 12, Name = "Early Childhood Development", Level = "advanced"},
            new Lecture {Id = 25, TeacherId = 8, Name = "VAS", Level = "advanced"},
            new Lecture {Id = 26, TeacherId = 11, Name = "Theatre", Level = "basic"},
            new Lecture {Id = 27, TeacherId = 24, Name = "OmniGraffle", Level = "advanced"},
            new Lecture {Id = 28, TeacherId = 27, Name = "Video", Level = "intermediate"},
            new Lecture {Id = 29, TeacherId = 14, Name = "CND", Level = "basic"},
            new Lecture {Id = 30, TeacherId = 10, Name = "Legal Issues", Level = "advanced"},
            new Lecture {Id = 31, TeacherId = 10, Name = "Fashion Blogging", Level = "intermediate"},
            new Lecture {Id = 32, TeacherId = 8, Name = "LTACH", Level = "basic"},
            new Lecture {Id = 33, TeacherId = 8, Name = "Education", Level = "intermediate"},
            new Lecture {Id = 34, TeacherId = 1, Name = "Fashion Illustration", Level = "advanced"},
            new Lecture {Id = 35, TeacherId = 24, Name = "Architectural Design", Level = "intermediate"},
            new Lecture {Id = 36, TeacherId = 9, Name = "Workshop Facilitation", Level = "intermediate"},
            new Lecture {Id = 37, TeacherId = 23, Name = "PPDS", Level = "intermediate"},
            new Lecture {Id = 38, TeacherId = 29, Name = "Corporate FP&amp;A", Level = "intermediate"},
            new Lecture {Id = 39, TeacherId = 19, Name = "Bylaws", Level = "basic"},
            new Lecture {Id = 40, TeacherId = 25, Name = "Win CVS", Level = "advanced"},
            new Lecture {Id = 41, TeacherId = 11, Name = "Program Evaluation", Level = "advanced"},
            new Lecture {Id = 42, TeacherId = 4, Name = "TGI", Level = "intermediate"},
            new Lecture {Id = 43, TeacherId = 9, Name = "Corporate Tax", Level = "basic"},
            new Lecture {Id = 44, TeacherId = 23, Name = "SEO", Level = "basic"},
            new Lecture {Id = 45, TeacherId = 2, Name = "Strategic HR", Level = "advanced"},
            new Lecture {Id = 46, TeacherId = 12, Name = "Lesson Planning", Level = "basic"},
            new Lecture {Id = 47, TeacherId = 24, Name = "Insurance", Level = "advanced"},
            new Lecture {Id = 48, TeacherId = 0, Name = "NVR", Level = "intermediate"},
            new Lecture {Id = 49, TeacherId = 26, Name = "Volunteer Recruiting", Level = "basic"},
            new Lecture {Id = 50, TeacherId = 5, Name = "Efficent", Level = "intermediate"},
            new Lecture {Id = 51, TeacherId = 23, Name = "CPCU", Level = "advanced"},
            new Lecture {Id = 52, TeacherId = 21, Name = "FFA", Level = "advanced"},
            new Lecture {Id = 53, TeacherId = 6, Name = "SSADM", Level = "advanced"},
            new Lecture {Id = 54, TeacherId = 9, Name = "Data Entry", Level = "basic"},
            new Lecture {Id = 55, TeacherId = 28, Name = "PET-CT", Level = "intermediate"},
            new Lecture {Id = 56, TeacherId = 27, Name = "GI", Level = "advanced"},
            new Lecture {Id = 57, TeacherId = 28, Name = "Global Management", Level = "intermediate"},
            new Lecture {Id = 58, TeacherId = 22, Name = "Validation", Level = "advanced"},
            new Lecture {Id = 59, TeacherId = 7, Name = "Aviation", Level = "advanced"},
            new Lecture {Id = 60, TeacherId = 7, Name = "Running", Level = "basic"},
            new Lecture {Id = 61, TeacherId = 7, Name = "FDA", Level = "advanced"},
            new Lecture {Id = 62, TeacherId = 8, Name = "RTL Coding", Level = "advanced"},
            new Lecture {Id = 63, TeacherId = 24, Name = "DLX", Level = "advanced"},
            new Lecture {Id = 64, TeacherId = 29, Name = "Military Training", Level = "intermediate"},
            new Lecture {Id = 65, TeacherId = 8, Name = "NCFM Certified", Level = "advanced"},
            new Lecture {Id = 66, TeacherId = 28, Name = "Music Education", Level = "intermediate"},
            new Lecture {Id = 67, TeacherId = 15, Name = "Karaoke", Level = "basic"},
            new Lecture {Id = 68, TeacherId = 0, Name = "Ffmpeg", Level = "basic"},
            new Lecture {Id = 69, TeacherId = 0, Name = "Benefits Administration", Level = "advanced"},
            new Lecture {Id = 70, TeacherId = 8, Name = "Electronics", Level = "basic"},
            new Lecture {Id = 71, TeacherId = 26, Name = "Grants", Level = "advanced"},
            new Lecture {Id = 72, TeacherId = 16, Name = "Inspection", Level = "intermediate"},
            new Lecture {Id = 73, TeacherId = 6, Name = "Social Media Marketing", Level = "basic"},
            new Lecture {Id = 74, TeacherId = 18, Name = "E-commerce", Level = "advanced"},
            new Lecture {Id = 75, TeacherId = 26, Name = "TL1", Level = "intermediate"},
            new Lecture {Id = 76, TeacherId = 5, Name = "PMC", Level = "basic"},
            new Lecture {Id = 77, TeacherId = 11, Name = "FTL", Level = "advanced"},
            new Lecture {Id = 78, TeacherId = 9, Name = "VLSI CAD", Level = "advanced"},
            new Lecture {Id = 79, TeacherId = 14, Name = "TSYS", Level = "advanced"},
            new Lecture {Id = 80, TeacherId = 3, Name = "Usability Testing", Level = "intermediate"},
            new Lecture {Id = 81, TeacherId = 7, Name = "DVB-C", Level = "basic"},
            new Lecture {Id = 82, TeacherId = 21, Name = "Sketching", Level = "basic"},
            new Lecture {Id = 83, TeacherId = 3, Name = "ABR", Level = "advanced"},
            new Lecture {Id = 84, TeacherId = 7, Name = "RDMA", Level = "intermediate"},
            new Lecture {Id = 85, TeacherId = 17, Name = "Geological Mapping", Level = "basic"},
            new Lecture {Id = 86, TeacherId = 23, Name = "Game Design", Level = "advanced"},
            new Lecture {Id = 87, TeacherId = 18, Name = "GPS Units", Level = "basic"},
            new Lecture {Id = 88, TeacherId = 19, Name = "Store Operations", Level = "intermediate"},
            new Lecture {Id = 89, TeacherId = 16, Name = "RSLinx", Level = "advanced"},
            new Lecture {Id = 90, TeacherId = 23, Name = "AU", Level = "advanced"},
            new Lecture {Id = 91, TeacherId = 7, Name = "Purchase Management", Level = "intermediate"},
            new Lecture {Id = 92, TeacherId = 8, Name = "NHPA", Level = "advanced"},
            new Lecture {Id = 93, TeacherId = 8, Name = "Failure Analysis", Level = "intermediate"},
            new Lecture {Id = 94, TeacherId = 19, Name = "Molecular Biology", Level = "advanced"},
            new Lecture {Id = 95, TeacherId = 8, Name = "Biotechnology", Level = "advanced"},
            new Lecture {Id = 96, TeacherId = 9, Name = "PVR", Level = "basic"},
            new Lecture {Id = 97, TeacherId = 27, Name = "Swift", Level = "intermediate"},
            new Lecture {Id = 98, TeacherId = 4, Name = "Yii", Level = "advanced"},
            new Lecture {Id = 99, TeacherId = 15, Name = "Structural Dynamics", Level = "advanced"},
            new Lecture {Id = 100, TeacherId = 23, Name = "LabVIEW", Level = "basic"},
            new Lecture {Id = 101, TeacherId = 11, Name = "Oil &amp; Gas", Level = "advanced"},
            new Lecture {Id = 102, TeacherId = 2, Name = "Ice Cream", Level = "advanced"},
            new Lecture {Id = 103, TeacherId = 26, Name = "Electrical Engineering", Level = "intermediate"},
            new Lecture {Id = 104, TeacherId = 16, Name = "Rugs", Level = "basic"},
            new Lecture {Id = 105, TeacherId = 26, Name = "Private Banking", Level = "intermediate"},
            new Lecture {Id = 106, TeacherId = 14, Name = "CGI scripts", Level = "basic"},
            new Lecture {Id = 107, TeacherId = 27, Name = "Legal Issues", Level = "advanced"},
            new Lecture {Id = 108, TeacherId = 20, Name = "XACT", Level = "advanced"},
            new Lecture {Id = 109, TeacherId = 25, Name = "eZ Publish", Level = "intermediate"},
            new Lecture {Id = 110, TeacherId = 17, Name = "Geophysics", Level = "intermediate"},
            new Lecture {Id = 111, TeacherId = 8, Name = "HCPCS", Level = "advanced"},
            new Lecture {Id = 112, TeacherId = 28, Name = "Forecasting", Level = "advanced"},
            new Lecture {Id = 113, TeacherId = 27, Name = "IRB", Level = "advanced"},
            new Lecture {Id = 114, TeacherId = 11, Name = "People Management", Level = "basic"},
            new Lecture {Id = 115, TeacherId = 5, Name = "Utility Regulation", Level = "advanced"},
            new Lecture {Id = 116, TeacherId = 18, Name = "Nursing Management", Level = "advanced"},
            new Lecture {Id = 117, TeacherId = 12, Name = "Global Business Development", Level = "advanced"},
            new Lecture {Id = 118, TeacherId = 17, Name = "SQR", Level = "intermediate"},
            new Lecture {Id = 119, TeacherId = 16, Name = "SMTP", Level = "basic"}
        };

        private static readonly Teacher[] _teachers =
        {
            new Teacher {Id = 1, GivenName = "Janet", LastName = "Nelson", Age = 41, Email = "dnelson0@ft.com"},
            new Teacher {Id = 2, GivenName = "Martha", LastName = "Brooks", Age = 42, Email = "mbrooks1@msu.edu"},
            new Teacher
            {
                Id = 3,
                GivenName = "Janice",
                LastName = "Franklin",
                Age = 44,
                Email = "jfranklin2@cornell.edu"
            },
            new Teacher {Id = 4, GivenName = "Martha", LastName = "Burke", Age = 26, Email = ""},
            new Teacher
            {
                Id = 5,
                GivenName = "Virginia",
                LastName = "Williams",
                Age = 50,
                Email = "vwilliams4@wikispaces.com"
            },
            new Teacher {Id = 6, GivenName = "Jonathan", LastName = "Graham", Age = 44, Email = ""},
            new Teacher {Id = 7, GivenName = "Helen", LastName = "Snyder", Age = 41, Email = "hsnyder6@tuttocitta.it"},
            new Teacher {Id = 8, GivenName = "George", LastName = "Jackson", Age = 21, Email = "gjackson7@apple.com"},
            new Teacher {Id = 9, GivenName = "Carol", LastName = "Frazier", Age = 38, Email = "cfrazier8@taobao.com"},
            new Teacher {Id = 10, GivenName = "Janet", LastName = "Little", Age = 38, Email = ""},
            new Teacher {Id = 11, GivenName = "Frank", LastName = "Hunt", Age = 24, Email = ""},
            new Teacher {Id = 12, GivenName = "Carl", LastName = "Foster", Age = 36, Email = "cfosterb@harvard.edu"},
            new Teacher {Id = 13, GivenName = "Margaret", LastName = "Burton", Age = 77, Email = ""},
            new Teacher {Id = 14, GivenName = "Carol", LastName = "James", Age = 30, Email = "cjamesd@com.com"},
            new Teacher {Id = 15, GivenName = "Shawn", LastName = "Hanson", Age = 40, Email = "shansone@linkedin.com"},
            new Teacher {Id = 16, GivenName = "Eugene", LastName = "Stevens", Age = 18, Email = "estevensf@g.co"},
            new Teacher {Id = 17, GivenName = "Maria", LastName = "Myers", Age = 23, Email = "mmyersg@prnewswire.com"},
            new Teacher {Id = 18, GivenName = "Terry", LastName = "Williams", Age = 26, Email = "tlawrenceh@wiley.com"},
            new Teacher {Id = 19, GivenName = "Phyllis", LastName = "Burns", Age = 33, Email = "pburnsi@umn.edu"},
            new Teacher
            {
                Id = 20,
                GivenName = "Emily",
                LastName = "Robertson",
                Age = 35,
                Email = "erobertsonj@oracle.com"
            },
            new Teacher
            {
                Id = 21,
                GivenName = "Janet",
                LastName = "Gordon",
                Age = 45,
                Email = "cgordonk@barnesandnoble.com"
            },
            new Teacher
            {
                Id = 22,
                GivenName = "Linda",
                LastName = "Ramirez",
                Age = 24,
                Email = "lramirezl@bravesites.com"
            },
            new Teacher {Id = 23, GivenName = "Lillian", LastName = "Lynch", Age = 39, Email = "llynchm@thetimes.co.uk"},
            new Teacher {Id = 24, GivenName = "Christopher", LastName = "Jackson", Age = 54, Email = ""},
            new Teacher {Id = 25, GivenName = "Laura", LastName = "Williams", Age = 67, Email = ""},
            new Teacher {Id = 26, GivenName = "William", LastName = "Allen", Age = 16, Email = "wallenp@army.mil"},
            new Teacher {Id = 27, GivenName = "Henry", LastName = "Arnold", Age = 33, Email = "harnoldq@exblog.jp"},
            new Teacher {Id = 28, GivenName = "Nancy", LastName = "Peters", Age = 39, Email = "npetersr@engadget.com"},
            new Teacher {Id = 29, GivenName = "Janet", LastName = "Torres", Age = 50, Email = "storress@npr.org"},
            new Teacher
            {
                Id = 30,
                GivenName = "Ruth",
                LastName = "Williams",
                Age = 26,
                Email = "rbishopt@ezinearticles.com"
            }
        };

        public Lecture[] Lectures
        {
            get { return _lectures; }
        }

        public Teacher[] Teachers
        {
            get { return _teachers; }
        }
    }
}