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
        private String _nrIndeksu;

       
        [XmlElement(elementName: "fname")]
        public string Imie
        {
            get { return _imie; }
            set
            {
                _imie = value ?? throw new ArgumentException();
            }
        }

        [XmlElement(elementName: "lname")]
        public string Nazwisko
        {
            get { return _nazwisko; }
            set
            {
                _nazwisko = value ?? throw new ArgumentException();
            }
        }

        [XmlElement(elementName: "birthdate")]
        public string DataUrodzenia
        {
            get { return _dataUrodzenia; }
            set
            {
                _dataUrodzenia = value ?? throw new ArgumentException();
            }
        }
        [XmlAttribute(attributeName: "email")]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value ?? throw new ArgumentException();
            }
        }

        [XmlElement(elementName: "mothersName")]
        public string ImieMatki
        {
            get { return _imieMatki; }
            set
            {
                _imieMatki = value ?? throw new ArgumentException();
            }
        }
        [XmlElement(elementName: "fathersName")]
        public string ImieOjca
        {
            get { return _imieOjca; }
            set
            {
                _imieOjca = value ?? throw new ArgumentException();
            }
        }
        [XmlElement(elementName: "studies")]
        public string Studia
        {
            get { return _studia; }
            set
            {
                _studia = value ?? throw new ArgumentException();
            }
        }
        [XmlElement(elementName: "mode")]
        public string Tryb
        {
            get { return _tryb; }
            set
            {
                _tryb = value ?? throw new ArgumentException();
            }
        }
        [XmlElement(elementName: "nrIndeksu=")]
        public string NrIndeksu     
        {
            get { return _nrIndeksu; }
            set
            {
                _nrIndeksu = value ?? throw new ArgumentException();
            }
        }
        //propfull + tabx2




    }
}
