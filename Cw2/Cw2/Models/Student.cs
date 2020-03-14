using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cw2.Models
{
    public class Student
    {

        private String _imie;
        private String _nazwisko;
        private String _imieMatki;
        private String _imieOjca;
        private String _dataUrodzenia;
        private String _email;
        private String _studia;
        private String _tryb;
        private String _utworzony;

        [XmlAttribute(attributeName:"email")]
        public string Email { get; set; }
        [XmlElement(elementName: "fname")]
        public string Imie { get; set; }

        [XmlElement(elementName: "birthdate")]
        public string DataUrodzenia { get; set; }
        [XmlElement(elementName: "mothersName")]
        public string ImieMatki { get; set; }
        [XmlElement(elementName: "fathersName")]
        public string ImieOjca { get; set; }
        [XmlElement(elementName: "studies")]
        public string Studia { get; set; }
        [XmlElement(elementName: "mode")]
        public string Tryb { get; set; }
        [XmlElement(elementName: "createdAt")]
        public string Utworzony { get; set; }

        //propfull + tabx2

        [XmlElement(elementName: "lname")]

        public string Nazwisko
        {
            get { return _nazwisko; }
            set
            {
                _nazwisko = value ?? throw new ArgumentException();
            }
        }

    }
}
