using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Versa.F_Core;
using Versa.F_Output;

namespace Versa.F_Module
{
    class Lewd
    {
        internal static List<string> TermsToToggleOff = new List<string>
        {
            "cloth",
            "shirt",
            "pant",
            "under",
            "undi",
            "jacket",
            "top",
            "bra",
            "Belts",
            "skirt",
            "jean",
            "trouser",
            "boxers",
            "hoodi",
            "bottom",
            "dress",
            "bandage",
            "bondage",
            "sweat",
            "cardig",
            "corset",
            "tiddy",
            "pastie",
            "suit",
            "stocking",
            "jewel",
            "frill",
            "gauze",
            "cover",
            "pubic",
            "sfw",
            "harn",
            "biki",
            "off",
            "harness",
            "bodysuit",
            "armnets",
            "boots",
            "glove",
            "disable"
        };

        internal static List<string> TermsToToggleOn = new List<string>
        {
            "penis",
            "dick",
            "cock",
            "futa",
            "dildo",
            "strap",
            "shlong",
            "dong",
            "vibrat",
            "lovense",
            "sex",
            "toy",
            "butt",
            "plug",
            "whip",
            "cum",
            "sperm",
            "facial",
            "nude",
            "naked",
            "nsfw"
        };
        internal static GameObject Avatar()
        {
            return GameApi.GetAvatar(GameApi.SelectedPlayer().prop_VRCPlayer_0);
        }
        public static async void MakeLewd(bool state)
        {
            try
            {
                if (state)
                    foreach (Animator Animator in Avatar().GetComponentsInChildren<Animator>(true))
                    {
                        Animator.enabled = false;
                    }
                else
                    foreach (Animator Animator in Avatar().GetComponentsInChildren<Animator>(true))
                    {
                        Animator.enabled = true;
                    }

                foreach (SkinnedMeshRenderer skinnedMeshRenderer in Avatar().GetComponentsInChildren<SkinnedMeshRenderer>(true))
                {
                    foreach (string value in TermsToToggleOn)
                    {
                        if (skinnedMeshRenderer.transform.name.ToLower().Contains(value))
                        {
                            if (skinnedMeshRenderer.transform.GetComponent<Animator>() != null)
                            {
                                if (state)
                                    skinnedMeshRenderer.transform.GetComponent<Animator>().enabled = true;
                                else
                                    skinnedMeshRenderer.transform.GetComponent<Animator>().enabled = false;
                            }
                            if (skinnedMeshRenderer.GetComponent<Animator>() != null)
                            {
                                if (state)
                                    skinnedMeshRenderer.GetComponent<Animator>().enabled = false;
                                else
                                    skinnedMeshRenderer.GetComponent<Animator>().enabled = true;
                            }
                            if (state)
                                skinnedMeshRenderer.transform.gameObject.SetActive(true);
                            else
                                skinnedMeshRenderer.transform.gameObject.SetActive(false);
                        }
                    }
                    foreach (string value2 in TermsToToggleOff)
                    {
                        if (skinnedMeshRenderer.transform.name.ToLower().Contains(value2))
                        {
                            if (skinnedMeshRenderer.transform.GetComponent<Animator>() != null)
                            {
                                if (state)
                                    skinnedMeshRenderer.transform.GetComponent<Animator>().enabled = false;
                                else
                                    skinnedMeshRenderer.transform.GetComponent<Animator>().enabled = false;
                            }
                            if (skinnedMeshRenderer.GetComponent<Animator>() != null)
                            {
                                if (state)
                                    skinnedMeshRenderer.GetComponent<Animator>().enabled = false;
                                else
                                    skinnedMeshRenderer.GetComponent<Animator>().enabled = true;
                            }
                            if (state)
                                skinnedMeshRenderer.transform.gameObject.SetActive(false);
                            else
                                skinnedMeshRenderer.transform.gameObject.SetActive(true);
                        }
                    }
                }
            }
            catch(Exception e) { CustomConsole.Console(true, "Lewd.cs: " + e.Message); }
        }
    }
}
