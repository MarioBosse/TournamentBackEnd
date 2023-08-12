//----------------------------------------------------------------------------------
//
// Gestion Informatique Mario Bossé (GiMB)
// @2023 Tout droit réservé. Reproducion interdite
//
// Concepteur : Mario Bossé
// 16 Juillet 2023
//
// Nom : GiDlls
// Description : GIMB est une firme de consultant qui effectu des mandants à la
//               pige. Cette  espace a été créé pour pouvoir y placer tous les
//               objects et les fonctions qui seront créé pouvant être réutilisées.
//
//----------------------------------------------------------------------------------
namespace GiDlls
{
    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Utils
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class Utils
    {
        //----------------------------------------------------------------------------------
        //
        // Concepteur : Mario Bossé
        // 4 Août 2023
        //
        // Niveau d'accès : Public
        // Base d'enregistrement : Aucun
        // Type de retour : String  Retourne une chaine de caratère en Base64 qui contient
        //                          le contenue du fichier binaire demandé.
        // Nom : BinaryFileToBase64
        // Description : Convertie le contenue du fichier binaire est chaine de caractère
        //               crypté en Base64.
        // Paramètres : String  filename    Nom du fichier à lire.
        //
        //----------------------------------------------------------------------------------
        public String BinaryFileToBase64(string filename)
        {
            return Convert.ToBase64String(File.ReadAllBytes(filename));
        }
    }


    //----------------------------------------------------------------------------------
    //
    // Concepteur : Mario Bossé
    // 16 Juillet 2023
    //
    // Définition de Class
    // Nom : Traitements
    // Héritage : Aucun
    //
    //----------------------------------------------------------------------------------
    public class Traitements
    {
    }
}