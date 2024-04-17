namespace PFE_API.Model
{
    public class Employee
    {
        public string Matricule { get; set; }
        public string NSS { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Prenom2 { get; set; }
        public string NomArabe { get; set; }
        public string PrenomArabe { get; set; }
        public string Prenom2Arabe { get; set; }
        public DateTime DateNaissance { get; set; }
        public string NomJeuneFille { get; set; }
        public string LieuNaissance { get; set; }
        public string PaysNaissance { get; set; }
        public string WilayaNaissance { get; set; }
        public string CommuneNaissance { get; set; }
        public string Sexe { get; set; }
        public string Titre { get; set; }
        public string SituationFamiliale { get; set; }
        public string Nationalites { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public int Reliquat { get; set; }
        public bool isResponsable { get; set; }
        public int IDEquipe { get; set; }
    }
}
