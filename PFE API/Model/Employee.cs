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
        public TypeSexe Sexe { get; set; }
        public TypeTitre Titre { get; set; }
        public TypeSituationFamiliale SituationFamiliale { get; set; }
        public string Nationalites { get; set; }
        public string LinkToPhoto { get; set; }
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
        [EmailAddress]
        public string Email { get; internal set; }
        public int Score { get; set; }

        public Employee() // Parameterless constructor
        {
            // Initialize properties with default values if needed
        }

        public Employee(string matricule, string nss, string nom, string prenom, string prenom2, string nomArabe, string prenomArabe, string prenom2Arabe, DateOnly dateNaissance, string nomJeuneFille, string lieuNaissance, string paysNaissance, string wilayaNaissance, string communeNaissance, TypeSexe sexe, TypeTitre titre, TypeSituationFamiliale situationFamiliale, string nationalites, string photo, int reliquat, bool isResponsable, int iDEquipe, string iDResponsable, DateOnly dateEntre, DateOnly? dateSortie, int nbAnneeExperienceInterne, int nbAnneeExperienceExterne, int? nbEnfant, string email)
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
            LinkToPhoto = photo;
            Reliquat = reliquat;
            IsResponsable = isResponsable;
            IDEquipe = iDEquipe;
            IDResponsable = iDResponsable;
            DateEntre = dateEntre;
            DateSortie = dateSortie;
            NbAnneeExperienceInterne = nbAnneeExperienceInterne;
            NbAnneeExperienceExterne = nbAnneeExperienceExterne;
            NbEnfant = nbEnfant;
            Email = email;
            Score = 0;
        }
    }

    public enum TypeTitre
    {
        Mr,
        Mme,
        Mlle,
        Me,
        Dr,
        Pr
    }

    public enum TypeSexe
    {
        M,
        F, 
        NonSpecifie
    }

    public enum TypeSituationFamiliale
    {
        Célibataire,
        Marié,
        Divorcé,
        Veuf
    }

    public class Contact
    {
        [Key]
        public int ID { get; set; }

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
