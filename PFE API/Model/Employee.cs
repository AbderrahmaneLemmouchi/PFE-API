using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_API.Model
{
    public class Employee
    {
        [Key]
        public string Matricule { get; set; }
        public string NSS { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string? Prenom2 { get; set; }
        public string NomArabe { get; set; }
        public string PrenomArabe { get; set; }
        public string? Prenom2Arabe { get; set; }
        public DateOnly DateNaissance { get; set; }
        public string? NomJeuneFille { get; set; }
        public string? NomJeuneFilleArabe { get; set; }
        public string LieuNaissance { get; set; }
        public string PaysNaissance { get; set; }
        public string WilayaNaissance { get; set; }
        public string CommuneNaissance { get; set; }
        public string Sexe { get; set; }
        public string Titre { get; set; }
        public string SituationFamiliale { get; set; }
        public string Nationalites { get; set; }
        public string Telephone { get; set; }
        public string? Mobile { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public int Reliquat { get; set; }
        public bool IsResponsable { get; set; }
        [ForeignKey("Equipe")]
        public int IDEquipe { get; set; }
        [ForeignKey("Employee")]
        public string? IDResponsable { get; set; }
        public DateOnly DateEntre { get; set; }
        public DateOnly? DateSortie { get; set; }
        public int NbAnneeExperienceInterne { get; set; }
        public int NbAnneeExperienceExterne { get; set; }
        public int? NbEnfant { get; set; }


        public Employee() // Parameterless constructor
        {
            // Initialize properties with default values if needed
        }

        public Employee(string matricule, string nss, string nom, string prenom, string prenom2, string nomArabe, string prenomArabe, string prenom2Arabe, DateOnly dateNaissance, string nomJeuneFille, string lieuNaissance, string paysNaissance, string wilayaNaissance, string communeNaissance, string sexe, string titre, string situationFamiliale, string nationalites, string telephone, string mobile, string email, byte[] photo, int reliquat, bool isResponsable, int iDEquipe, string iDResponsable, DateOnly dateEntre, DateOnly? dateSortie, int nbAnneeExperienceInterne, int nbAnneeExperienceExterne, int? nbEnfant)
        {
            Matricule = matricule;
            NSS = nss;
            Nom = nom;
            Prenom = prenom;
            Prenom2 = prenom2;
            NomArabe = nomArabe;
            PrenomArabe = prenomArabe;
            Prenom2Arabe = prenom2Arabe;
            DateNaissance = dateNaissance;
            NomJeuneFille = nomJeuneFille;
            LieuNaissance = lieuNaissance;
            PaysNaissance = paysNaissance;
            WilayaNaissance = wilayaNaissance;
            CommuneNaissance = communeNaissance;
            Sexe = sexe;
            Titre = titre;
            SituationFamiliale = situationFamiliale;
            Nationalites = nationalites;
            Telephone = telephone;
            Mobile = mobile;
            Email = email;
            Photo = photo;
            Reliquat = reliquat;
            IsResponsable = isResponsable;
            IDEquipe = iDEquipe;
            IDResponsable = iDResponsable;
            DateEntre = dateEntre;
            DateSortie = dateSortie;
            NbAnneeExperienceInterne = nbAnneeExperienceInterne;
            NbAnneeExperienceExterne = nbAnneeExperienceExterne;
            NbEnfant = nbEnfant;
        }
    }

    [PrimaryKey(nameof(MatriculeEmp), nameof(Type), nameof(Valeur))]
    public class Contact
    {
        [ForeignKey("Employee")]
        public string MatriculeEmp { get; set; } 
        public string Type { get; set; }
        public string Valeur { get; set; }

        public Contact()
        {
            
        }

        public Contact(string matriculeEmp, string type, string valeur)
        {
            MatriculeEmp = matriculeEmp;
            Type = type;
            Valeur = valeur;
        }
    }

}
