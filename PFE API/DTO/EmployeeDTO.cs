using PFE_API.Model;

namespace PFE_API.DTO
{
    public class EmployeeDTO
    {
        //string Matricule,
        //string NSS,
        //string Nom,
        //string Prenom,
        //string? Prenom2,
        //string NomArabe,
        //string PrenomArabe,
        //string? Prenom2Arabe,
        //DateOnly DateNaissance,
        //string? NomJeuneFille,
        //string? NomJeuneFilleArabe,
        //string LieuNaissance,
        //string PaysNaissance,
        //string WilayaNaissance,
        //string CommuneNaissance,
        //string Sexe,
        //string Titre,
        //string SituationFamiliale,
        //string Nationalites,
        //string LinkToPhoto,
        //int Reliquat,
        //bool IsResponsable,
        //int IDEquipe,
        //string? IDResponsable,
        //DateOnly DateEntre,
        //DateOnly? DateSortie,
        //int NbAnneeExperienceInterne,
        //int NbAnneeExperienceExterne,
        //int? NbEnfant,
        //string Email
        //);

        public string Matricule { get; set; }
        public string? NSS { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Prenom2 { get; set; }
        public string? NomArabe { get; set; }
        public string? PrenomArabe { get; set; }
        public string? Prenom2Arabe { get; set; }
        public DateOnly? DateNaissance { get; set; }
        public string? NomJeuneFille { get; set; }
        public string? NomJeuneFilleArabe { get; set; }
        public string LieuNaissance { get; set; }
        public string? PaysNaissance { get; set; }
        public string? WilayaNaissance { get; set; } //
        public string? CommuneNaissance { get; set; } //
        public string? Sexe { get; set; }
        public string? Titre { get; set; } //
        public string? SituationFamiliale { get; set; }
        public string? Nationalites { get; set; } //
        public string? LinkToPhoto { get; set; } //
        public int? Reliquat { get; set; } //
        public bool? IsResponsable { get; set; } //
        public int? IDEquipe { get; set; }
        public string? IDResponsable { get; set; } //
        public DateOnly? DateEntre { get; set; } //
        public DateOnly? DateSortie { get; set; }
        public int? NbAnneeExperienceInterne { get; set; } //
        public int? NbAnneeExperienceExterne { get; set; } //
        public int? NbEnfant { get; set; }
        public string? Email { get; set; }
        public string? password { get; set; }
        public string? role { get; set; }

        public EmployeeDTO(string? matricule, string nSS, string nom, string prenom, string? prenom2, string nomArabe, string prenomArabe, string? prenom2Arabe, DateOnly dateNaissance, string? nomJeuneFille, string? nomJeuneFilleArabe, string lieuNaissance, string paysNaissance, string wilayaNaissance, string communeNaissance, string sexe, string titre, string situationFamiliale, string nationalites, string linkToPhoto, int reliquat, bool isResponsable, int iDEquipe, string? iDResponsable, DateOnly dateEntre, DateOnly? dateSortie, int nbAnneeExperienceInterne, int nbAnneeExperienceExterne, int? nbEnfant, string email)
        {
            Matricule = matricule;
            NSS = nSS;
            Nom = nom;
            Prenom = prenom;
            Prenom2 = prenom2;
            NomArabe = nomArabe;
            PrenomArabe = prenomArabe;
            Prenom2Arabe = prenom2Arabe;
            DateNaissance = dateNaissance;
            NomJeuneFille = nomJeuneFille;
            NomJeuneFilleArabe = nomJeuneFilleArabe;
            LieuNaissance = lieuNaissance;
            PaysNaissance = paysNaissance;
            WilayaNaissance = wilayaNaissance;
            CommuneNaissance = communeNaissance;
            Sexe = sexe;
            Titre = titre;
            SituationFamiliale = situationFamiliale;
            Nationalites = nationalites;
            LinkToPhoto = linkToPhoto;
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
        }

        public static EmployeeDTO FromEmployee(Employee employee)
        {
            return new EmployeeDTO(
                               employee.Matricule,
                                              employee.NSS,
                                                             employee.Nom,
                                                                            employee.Prenom,
                                                                                           employee.Prenom2,
                                                                                                          employee.NomArabe,
                                                                                                                         employee.PrenomArabe,
                                                                                                                                        employee.Prenom2Arabe,
                                                                                                                                                       employee.DateNaissance.Value,
                                                                                                                                                                      employee.NomJeuneFille,
                                                                                                                                                                                     employee.NomJeuneFilleArabe,
                                                                                                                                                                                                    employee.LieuNaissance,
                                                                                                                                                                                                                   employee.PaysNaissance,
                                                                                                                                                                                                                                  employee.WilayaNaissance,
                                                                                                                                                                                                                                                 employee.CommuneNaissance,
                                                                                                                                                                                                                                                                employee.Sexe.ToString(),
                                                                                                                                                                                                                                                                               employee.Titre.ToString(),
                                                                                                                                                                                                                                                                                              employee.SituationFamiliale.ToString(),
                                                                                                                                                                                                                                                                                                             employee.Nationalites,
                                                                                                                                                                                                                                                                                                                            employee.LinkToPhoto,
                                                                                                                                                                                                                                                                                                                                           employee.Reliquat.Value,
                                                                                                                                                                                                                                                                                                                                                          employee.IsResponsable,
                                                                                                                                                                                                                                                                                                                                                                         employee.IDEquipe.Value,
                                                                                                                                                                                                                                                                                                                                                                                        employee.IDResponsable,
                                                                                                                                                                                                                                                                                                                                                                                                       employee.DateEntre.Value,
                                                                                                                                                                                                                                                                                                                                                                                                                      employee.DateSortie,
                                                                                                                                                                                                                                                                                                                                                                                                                                     employee.NbAnneeExperienceInterne.Value,
                                                                                                                                                                                                                                                                                                                                                                                                                                                    employee.NbAnneeExperienceExterne.Value,
                                                                                                                                                                                                                                                                                                                                                                                                                                                                   employee.NbEnfant,
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  employee.Email
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             );
        }

        internal Employee ToEmployee()
        {
            return new Employee
            {
                Matricule = Matricule,
                NSS = NSS,
                Nom = Nom,
                Prenom = Prenom,
                Prenom2 = Prenom2,
                NomArabe = NomArabe,
                PrenomArabe = PrenomArabe,
                Prenom2Arabe = Prenom2Arabe,
                DateNaissance = DateNaissance,
                NomJeuneFille = NomJeuneFille,
                NomJeuneFilleArabe = NomJeuneFilleArabe,
                LieuNaissance = LieuNaissance,
                PaysNaissance = PaysNaissance,
                WilayaNaissance = WilayaNaissance,
                CommuneNaissance = CommuneNaissance,
                Sexe = (TypeSexe)Enum.Parse(typeof(TypeSexe), Sexe),
                Titre = (TypeTitre)Enum.Parse(typeof(TypeTitre), Titre),
                SituationFamiliale = (TypeSituationFamiliale)Enum.Parse(typeof(TypeSituationFamiliale), SituationFamiliale), 
                Nationalites = Nationalites,
                LinkToPhoto = LinkToPhoto,
                Reliquat = Reliquat,
                IsResponsable = IsResponsable == null ? false : IsResponsable.Value,
                IDEquipe = IDEquipe,
                IDResponsable = IDResponsable,
                DateEntre = DateEntre,
                DateSortie = DateSortie,
                NbAnneeExperienceInterne = NbAnneeExperienceInterne,
                NbAnneeExperienceExterne = NbAnneeExperienceExterne,
                NbEnfant = NbEnfant,
                Email = Email
            };
        }
    }
}
