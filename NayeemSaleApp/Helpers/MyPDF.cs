using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using System;


namespace NayeemSaleApp.Helpers
{
public class MyPDF
    {
        private readonly string rootPath;
        private readonly IConverter _converter;
        //private readonly string baseUrl;

        public MyPDF(IHostingEnvironment hostingEnvironment, IConverter converter)
        {
            this.rootPath = hostingEnvironment.ContentRootPath + "/wwwroot/pdf/";
            _converter = converter;
            //this.baseUrl = "http://localhost:5000/";
        }

        public string GeneratePDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 12, Bottom = 9, Left = 14, Right = 14 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }
            return status;
        }
        public string GeneratePDF1(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 12, Bottom = 9, Left = 14, Right = 14 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }
            return status;
        }

        public string GeneratePDFVoucher(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 14, Bottom = 9, Left = 14, Right = 14 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }

        public string GenerateIOU7PDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 40, Bottom =12, Left = 14, Right = 14 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }
        public string GenerateIOUPDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 35, Bottom = 12, Left = 14, Right = 14 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }
        public string GenerateCRMPDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 12, Bottom = 0, Left = 0, Right = 10 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        //FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }
        public string GeneratePDF_WithoutPAD(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 40, Bottom = 40, Left = 14, Right = 14 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }

        public string GeneratePDF_WithPAD(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 12, Bottom = 30, Left = 14, Right = 14 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }

        public string GenerateCPDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 45, Bottom = 15, Left = 14, Right = 14 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Center = " " },
                        
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }
        public string GenerateSPDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.Legal,
                    Margins = new MarginSettings() { Top = 80, Bottom = 30, Left = 7, Right = 7 },
                  
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = " " },
                        

                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }
        public string GenerateLandscapePDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus,
                    Margins = new MarginSettings() { Top = 12, Bottom = 9, Left = 7, Right = 7 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = " " },
                        Page =url,
                    }
                }
            };



            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }

        public string GenerateLandscapePDFA4(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 24, Bottom = 9, Left = 20, Right = 10 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = " " },
                        Page =url,
                    }
                }
            };
            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }
            return status;
        }

        public string GenerateLandscapeEXCEL(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.LegalExtra,
                    //Margins = new MarginSettings() { Top = 12, Bottom = 9, Left = 7, Right = 7 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        //PagesCount = true,
                        //HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        //FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = " " },
                        Page =url,
                    }
                }
            };



            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }
        public string GenerateLandscapePDF_WithPad(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus,
                    Margins = new MarginSettings() { Top = 12, Bottom = 25, Left = 7, Right = 7 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Center = " " },
                        Page =url,
                    }
                }
            };



            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }

        public string GenerateLandscapePDF_A3(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A3Extra,
                    Margins = new MarginSettings() { Top = 12, Bottom = 9, Left = 7, Right = 7 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }

        public string GeneratePDFProjectStatus(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings() { Top = 12, Bottom = 9, Left = 14, Right = 7 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }
            return status;
        }

        public string GeneratePOSPDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = new PechkinPaperSize("65mm","3275mm"),

                    Margins = new MarginSettings() { Top = 0, Bottom = 0, Left = .5, Right =0 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }

        public string GeneratePOSReceiptPDF(out string fileName, string url)
        {
            string status = "done";
            fileName = "Document_" + DateTime.Now.ToString("yyyy-MM-dd_HH-ss") + ".pdf";

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = new PechkinPaperSize("65mm","327mm"),

                    Margins = new MarginSettings() { Top = 0, Bottom = 0, Left = .5, Right =0 },
                    Out = rootPath+fileName
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        PagesCount = true,
                        HeaderSettings = { FontName = "Arial", FontSize = 3, Right = "", Line = false, HtmUrl=""},
                        FooterSettings = { FontName = "Arial", FontSize = 6, Line = true, Center = " " },
                        Page =url,
                    }
                }
            };

            try
            {
                _converter.Convert(doc);
            }
            catch (Exception e)
            {
                status = e.Message;
            }

            return status;
        }
    }    
}
