using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class filterObject
    {
        public List<string[]> filterList = new List<string[]>();


        public bool findElement(string filter)
        {
            foreach (string[] a in filterList)
            {
                switch (a[0])
                {
                    case "blackWhite":
                        if(filter == "blackWhite")
                        {
                            return true;
                        }
                        break;
                    case "mean":
                        if (filter == "mean")
                        {
                            return true;
                        }
                        break;
                    case "median":
                        if (filter == "median")
                        {
                            return true;
                        }
                        break;
                    case "gaussian":
                        if (filter == "gaussian")
                        {
                            return true;
                        }
                        break;
                    case "brightness":
                        if (filter == "brightness")
                        {
                            return true;
                        }
                        break;
                    case "contrast":
                        if (filter == "contrast")
                        {
                            return true;
                        }
                        break;
                    case "difference":
                        if (filter == "difference")
                        {
                            return true;
                        }
                        break;
                    case "homogenity":
                        if (filter == "homogenity")
                        {
                            return true;
                        }
                        break;
                    case "sobel":
                        if (filter == "sobel")
                        {
                            return true;
                        }
                        break;
                    case "canny":
                        if (filter == "canny")
                        {
                            return true;
                        }
                        break;
                    case "sauvola":
                        if (filter == "sauvola")
                        {
                            return true;
                        }
                        break;
                    case "otsu":
                        if (filter == "otsu")
                        {
                            return true;
                        }
                        break;
                    case "kuwahara":
                        if (filter == "kuwahara")
                        {
                            return true;
                        }
                        break;
                    case "wavelet":
                        if (filter == "wavelet")
                        {
                            return true;
                        }
                        break;
                    case "cmean":
                        if (filter == "cmean")
                        {
                            return true;
                        }
                        break;
                    case "kmean":
                        if (filter == "kmean")
                        {
                            return true;
                        }
                        break;
                    case "shearlet":
                        if (filter == "shearlet")
                        {
                            return true;
                        }
                        break;
                }
            }
            return false;
        }


        public void findAndReplace(string filter, string param)
        {
            bool elementFound = false;
            if(filterList.Count == 0)
            {
                string[] newElement = new string[] { filter, param };
                filterList.Add(newElement);
            }
            else
            {
                int loopPlace = 0;
                int numToDelete = -1;
                foreach (string[] a in filterList)
                {
                    if(elementFound == true)
                    {
                        break;
                    }
                    switch (a[0])
                    {
                        case "blackWhite":
                                if(filter == "blackWhite")
                            {
                                Console.WriteLine("BlackWhite");
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "mean":
                            if(filter == "mean")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "median":
                            if(filter == "median")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "gaussian":
                            if (filter == "gaussian")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "brightness":
                            if (filter == "brightness")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "contrast":
                            if (filter == "contrast")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "difference":
                            if (filter == "difference")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "homogenity":
                            if (filter == "homogenity")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "sobel":
                            if (filter == "sobel")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "canny":
                            if (filter == "canny")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "sauvola":
                            if (filter == "sauvola")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "otsu":
                            if (filter == "otsu")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "kuwahara":
                            if (filter == "kuwahara")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "wavelet":
                            if (filter == "wavelet")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "cmean":
                            if (filter == "cmean")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "kmean":
                            if (filter == "kmean")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                        case "shearlet":
                            if (filter == "shearlet")
                            {
                                elementFound = true;
                                if (param == "0")
                                {
                                    numToDelete = loopPlace;
                                }
                                else
                                {
                                    a[1] = param;
                                }
                            }
                            break;
                    }
                    loopPlace += 1;
                }
                if (elementFound == false)
                {
                    string[] newElement = new string[] { filter, param };
                    filterList.Add(newElement);
                }
                if(numToDelete != -1)
                {
                    filterList.RemoveAt(numToDelete);
                    numToDelete = -1;
                }
            }
        }
    }
}
