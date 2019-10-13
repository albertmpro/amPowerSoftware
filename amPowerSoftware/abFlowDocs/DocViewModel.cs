using Albert.Standard.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using static Albert.Standard.Win32.Win32IO;
using static Albert.Standard.Win32.MediaCv;
using System.Windows.Controls;
using Albert.Standard;
using System.Windows.Ink;
using System.Xml.Linq;
using abFlowDocs.Controls;
using static Albert.Standard.Core;
using static System.Convert;
using System.Windows.Documents;
using System.Windows;
using System.IO;

namespace abFlowDocs
{
    public class DocViewModel : ViewModel
    {
        public DocViewModel()
        {
            ArtBoardInit();


        }

        #region Method's for Everything
        /// <summary>
        /// Method to Export to Png FOrmat 
        /// </summary>
        /// <param name="_element"></param>
        public void ExportPng(FrameworkElement _element)
        {
            ExportPng(_element);
        }
        /// <summary>
        /// Tuple update TabItem info Quickly 
        /// </summary>
        /// <param name="_fileName"></param>
        /// <param name="_tabitem"></param>
        /// <returns></returns>
        public (string FileName, FileInfo FileInfo) UpdateTabInfo(string _fileName, DocumentTabItem _tabitem)
        {
            //Setup FileInfo
            _tabitem.FileInfo = new FileInfo(_fileName);
            _tabitem.CurrentFile = _fileName;
            _tabitem.Header = _tabitem.FileInfo.Name;

            //Send a Message
            Message($"Your TabItem is hosting {_tabitem.FileInfo.Name} from the{_tabitem.FileInfo.DirectoryName} directory");


            //Return Value 
            return (_fileName, _tabitem.FileInfo);


        }
        #endregion


        #region ArtBoard 
        //Field's
        VMList<BrushModel> sizes, brushes;
        VMList<ArtBoardModel> absizes, abthemes;
        void ArtBoardInit()
        {

            //Create a NewBoard 
            NewBoard = new ArtBoardModel();

            #region Artboard List 
            //AB Sizes in Pixels
            absizes = new VMList<ArtBoardModel>();
            absizes.Add(new ArtBoardModel(1920, 1080) { Name = "1920 x 1080" });
            absizes.Add(new ArtBoardModel(1080, 1920) { Name = "1080 x 1920" });
            absizes.Add(new ArtBoardModel(1400, 800) { Name = "1400 x 800" });
            absizes.Add(new ArtBoardModel(1366, 768) { Name = "1366 x 768" });
            absizes.Add(new ArtBoardModel(1024, 768) { Name = "1024 x 768" });
            absizes.Add(new ArtBoardModel(1024) { Name = "1024 x 1024" });
            absizes.Add(new ArtBoardModel(800, 600) { Name = "800 x 600" });
            absizes.Add(new ArtBoardModel(700, 400) { Name = "700 x 400" });
            absizes.Add(new ArtBoardModel(504) { Name = "504 x 504" });
            absizes.Add(new ArtBoardModel(256) { Name = "256 x 256" });
            absizes.Add(new ArtBoardModel(100) { Name = "100 x 100" });

            //ABThemes 
            abthemes = new VMList<ArtBoardModel>();
            abthemes.Add(new ArtBoardModel("#ff000000", "#FFE4DCDC") { Name = "Normal" });
            abthemes.Add(new ArtBoardModel("#ff000000", "#FFBDBA63") { Name = "Old" });
            abthemes.Add(new ArtBoardModel("#ff000000", "#FF69BDE9") { Name = "BluePaper" });
            abthemes.Add(new ArtBoardModel("#ffffffff", "#ff000000") { Name = "BlackBoard" });
            abthemes.Add(new ArtBoardModel("#ffffffff", "#FF0E1A99") { Name = "BluePrint" });
            abthemes.Add(new ArtBoardModel("#ffffffff", "#FF195809") { Name = "Caulkboard" });
            abthemes.Add(new ArtBoardModel("#ffffffff", "#FF9F1616") { Name = "RedPrint" });
            #endregion

            #region Brush List 
            //Sizes 
            sizes = new VMList<BrushModel>();
            sizes.Add(new BrushModel(3) { Name = "Pencil 1" });
            sizes.Add(new BrushModel(5) { Name = "Pencil 2" });
            sizes.Add(new BrushModel(10) { Name = "Pencil 3" });
            sizes.Add(new BrushModel(15) { Name = "Pen 1" });
            sizes.Add(new BrushModel(20) { Name = "Pen 2" });
            sizes.Add(new BrushModel(25) { Name = "Pen 3" });
            sizes.Add(new BrushModel(30) { Name = "Pen 4" });
            sizes.Add(new BrushModel(35) { Name = "Marker 1" });
            sizes.Add(new BrushModel(40) { Name = "Marker 2" });
            sizes.Add(new BrushModel(45) { Name = "Marker 3" });
            sizes.Add(new BrushModel(50) { Name = "Marker 4" });
            sizes.Add(new BrushModel(55) { Name = "PaintBrush 1" });
            sizes.Add(new BrushModel(60) { Name = "PaintBrush 2" });
            sizes.Add(new BrushModel(65) { Name = "PaintBrush 3" });
            sizes.Add(new BrushModel(70) { Name = "PaintBrush 4" });

            //Brushes
            brushes = new VMList<BrushModel>();
            brushes.Add(new BrushModel("#ff000000") { Name = "Black" });
            brushes.Add(new BrushModel("#FF525252") { Name = "Black" });
            brushes.Add(new BrushModel("#FFAAAAAA") { Name = "Dark Grey" });
            brushes.Add(new BrushModel("#FFAF7D1A") { Name = "Skin 1" });
            brushes.Add(new BrushModel("#FFDE9D20") { Name = "Skin 2" });
            brushes.Add(new BrushModel("#FFECAD32") { Name = "Skin 3" });
            brushes.Add(new BrushModel("#FFFF0000") { Name = "Red" });
            brushes.Add(new BrushModel("#FFFFA800") { Name = "Orange" });
            brushes.Add(new BrushModel("#FFF9FF00") { Name = "Yellow" });
            brushes.Add(new BrushModel("#FFF9FF00") { Name = "Green" });
            brushes.Add(new BrushModel("#FF00B9C0") { Name = "Light Blue" });
            brushes.Add(new BrushModel("#FF002EC0") { Name = "Blue" });
            brushes.Add(new BrushModel("#FF730599") { Name = "Purple" });
            brushes.Add(new BrushModel("#FFE607ED") { Name = "Pink" });
            #endregion


        }





        /// <summary>
        /// Art Brush Color Tuple 
        /// </summary>
        /// <param name="_color"></param>
        /// <returns></returns>
        public (Color ColorOutput, SolidColorBrush BrushOutput) CreateArtBrush(byte _alpha, Color _color)
        {
            //Convert Color to Brush Type
            var rvColor = Color.FromArgb(_alpha, _color.R, _color.G, _color.B);

            //Return the Color 
            return (rvColor, new SolidColorBrush(rvColor));
        }

        public (string FileName, FileInfo FileInfo) SaveArtBoard(InkCanvas _inkCanvas, string _fileName)
        {
            //Save the Ink Strokes 
            SaveInkStrokes(_inkCanvas, _fileName);
            //Setup File Info 
            var fileinfo = new FileInfo(_fileName);

            return (_fileName, fileinfo);
        }

        public (string FileName, FileInfo FileIffo) LoadArtBoard(string _fileName, InkCanvas _inkcanvas)
        {
            //Save the Ink Strokes 
            LoadInkStrokes(_inkcanvas, _fileName);
            //Setup File Info 
            var fileinfo = new FileInfo(_fileName);

            return (_fileName, fileinfo);
        }


        /// <summary>
        /// Tuple ot create new ArtBoard
        /// </summary>
        /// <returns>Width, Height,SolidBrush,Color,InkCanvas</returns>
        public (double width, double height, SolidColorBrush background, Color brushcolor) NewArtBoard(ArtBoardModel _model)
        {
            return (_model.Width, _model.Height, new SolidColorBrush(_model.BackgroundColor), _model.BrushColor);
        }
        /// <summary>
        /// Gets or sets the Alpha value of the Artboard Brush 
        /// </summary>
        public byte AlphaColor { get; set; }
        /// <summary>
        /// Get or sets the Old Color Used 
        /// </summary>
        public Color OldColor { get; set; }
        /// <summary>
        /// Get or Set the New Board
        /// </summary>
        public ArtBoardModel NewBoard { get; set; }


        /// <summary>
        /// Get or set Artboard Sizes 
        /// </summary>
        public VMList<ArtBoardModel> ArtBoards
        {
            get { return absizes; }
            set { absizes = value; OnPropertyChanged("ArtBords"); }
        }
        /// <summary>
        /// Get or set Artboard Startup Theme's 
        /// </summary>
        public VMList<ArtBoardModel> ABThemes
        {
            get { return abthemes; }
            set { abthemes = value; OnPropertyChanged("ABThemes"); }
        }

        /// <summary>
        /// Get or set Preset Bruehses 
        /// </summary>
        public VMList<BrushModel> BrushColors
        {
            get { return brushes; }
            set { brushes = value; OnPropertyChanged("Brushes"); }
        }
        /// <summary>
        /// Get or set Sizes 
        /// </summary>
        public VMList<BrushModel> BrushSizes
        {
            get { return sizes; }
            set { sizes = value; OnPropertyChanged("Sizes"); }
        }



        #endregion


        #region Text Editor 

        public (string Title, string Description, string Author, string Tags, string Output) HTMLTemplate(string _title, string _description, string _author, string _tags)
        {
            //Generate the Html document 
            var output = $"<!DOCTYPE html>\n<html><head>\n<title>{_title}</title>\n<meta name=\"viewport\" content=\"width = device - width,initial - scale = 1\">\n<meta name=\"description\" content=\"{_description}\" >\n<meta name=\"author\" content=\"{_author}\" >\n<meta name=\"keywords\"  content=>\"{_tags}\"n</head>\n<body>\n</body>\n</html>";
            return (_title, _description, _author, _tags, output);

        }


        /// <summary>
        /// A Tuple to handle Filters for saving files 
        /// </summary>
        /// <returns></returns>
        public (string Text, string Ink, string Msg) Filters()
        {
            //Text Filter 
            var txt = MakeFilter("All Files (.)", ".*");
            //Ink Filter 
            var ink = MakeFilter("AB Ink(.abink)", ".abink");
            //Msg Filter 
            var msg = MakeFilter("AB Msg(.abmsg)", ".abmsg");




            return (txt, ink, msg);
        }
        #endregion


        #region Msg 
        /// <summary>
        /// Tuple to save a Rich Msg Document 
        /// </summary>
        /// <param name="_rtb">RichTextBlock</param>
        /// <param name="_filename"></param>
        /// <returns>Return's a XElement and the File Name</returns>
        public (XElement Output, string FileName) SaveMsg(RichTextBlock _rtb, string _filename)
        {
            //Setup your Xml file 
            var xml = new XElement("abflowdoc");
            var document = new XElement("msg");


            //Convert the Color's 
            var background = (SolidColorBrush)_rtb.Background;
            var textcolor = (SolidColorBrush)_rtb.Foreground;
            var bordercolor = (SolidColorBrush)_rtb.BorderBrush;

            //Grab the Text
            var textrange = new TextRange(_rtb.Document.ContentStart, _rtb.Document.ContentEnd);
            var text = textrange.Text;



            //Create your Xml Document 
            document.Add(new XElement("text", text));
            document.Add(new XAttribute("fontfamily", _rtb.FontFamily));
            document.Add(new XAttribute("width", _rtb.Width));
            document.Add(new XAttribute("height", _rtb.Height));
            document.Add(new XAttribute("fontsize", _rtb.FontSize));
            document.Add(new XAttribute("borderthickness", _rtb.BorderThickness.Top));
            document.Add(new XAttribute("cornerradius", _rtb.CornerRadius.TopLeft));
            document.Add(new XAttribute("background", background.Color));
            document.Add(new XAttribute("foreground", textcolor.Color));
            document.Add(new XAttribute("border", bordercolor.Color));


            //add to the xml output 
            xml.Add(document);
            //Save the Xml File 
            xml.Save(_filename);

            //Return the Xml Document 
            return (xml, _filename);

        }
        /// <summary>
        /// Tuple to save a Msg Document 

        /// </summary>
        /// <param name="_txt">ATextField</param>
        /// <param name="_filename">File Name</param>

        /// <returns></returns>
        public (XElement Output, string FileName) SaveMsg(ATextField _txt, string _filename)
        {
            //Setup your Xml file 
            var xml = new XElement("abflowdoc");
            var document = new XElement("msg");

            //Convert the Color's 
            var background = (SolidColorBrush)_txt.Background;
            var textcolor = (SolidColorBrush)_txt.Foreground;
            var bordercolor = (SolidColorBrush)_txt.BorderBrush;

            //Grab the text 
            var text = _txt.Text;

            //Create your Xml Document 
            document.Add(new XElement("text", text));
            document.Add(new XAttribute("width", _txt.Width));
            document.Add(new XAttribute("heihgt", _txt.Height));
            document.Add(new XAttribute("fontfamily", _txt.FontFamily));
            document.Add(new XAttribute("fontsize", _txt.FontSize));
            document.Add(new XAttribute("borderthickness", _txt.BorderThickness.Top));
            document.Add(new XAttribute("cornerradius", _txt.CornerRadius.TopLeft));
            document.Add(new XAttribute("background", background.Color));
            document.Add(new XAttribute("foreground", textcolor.Color));
            document.Add(new XAttribute("border", bordercolor.Color));



            xml.Add(document);
            xml.Save(_filename);

            //Return the Xml Document 
            return (xml, _filename);
        }
        /// <summary>
        /// Tuple to Load Msg to RichTextBlock
        /// </summary>
        /// <param name="_fileName">File Name</param>
        /// <param name="_rtb">RichText Block to Populate</param>
        /// <returns>Xml Output and File Name</returns>
        public (XElement Output, string FileName) LoadMsg(string _fileName, RichTextBlock _rtb)
        {
            var xml = XElement.Load(_fileName);

            //Grab the Document 
            var document = xml.Element("msg");
            //Convert doubles
            var width = ToDouble(document.Attribute("width").Value);
            var height = ToDouble(document.Attribute("heght").Value);
            var thickness = ToDouble(document.Attribute("borderthickness").Value);
            var cornerradius = ToDouble(document.Attribute("cornerradius").Value);
            var fontsize = ToDouble(document.Attribute("fontsize"));
            //Convert Colors 
            var background = HexBrush(document.Attribute("background").Value);
            var foreground = HexBrush(document.Attribute("foreground").Value);
            var border = HexBrush(document.Attribute("border").Value);
            //Font Family 
            var fontfamily = document.Attribute("fontfamily").Value;

            //Grab the Text 
            var text = document.Element("text").Value;

            //Fill up the RichTextBlock 
            var textrange = new TextRange(_rtb.Document.ContentStart, _rtb.Document.ContentEnd);
            textrange.Text = "";
            textrange.Text = text;
            _rtb.FontFamily = new FontFamily(fontfamily);
            _rtb.FontSize = fontsize;
            _rtb.Width = width;
            _rtb.Height = height;
            _rtb.CornerRadius = new CornerRadius(cornerradius);
            _rtb.BorderThickness = new Thickness(thickness);
            _rtb.Background = background;
            _rtb.Foreground = foreground;
            _rtb.BorderBrush = border;

            return (xml, _fileName);
        }
        /// <summary>
        /// Tuple to Load Msg to ATextField
        /// </summary>
        /// <param name="_filename">File Name</param>
        /// <param name="_txt">ATextField to populate</param>
        /// <returns></returns>
        public (XElement Output, string FileName) LoadMsg(string _filename, ATextField _txt)
        {
            var xml = XElement.Load(_filename);

            //Grab the Document 
            var document = xml.Element("msg");
            //Convert doubles
            var width = ToDouble(document.Attribute("width").Value);
            var height = ToDouble(document.Attribute("heght").Value);
            var thickness = ToDouble(document.Attribute("borderthickness").Value);
            var cornerradius = ToDouble(document.Attribute("cornerradius").Value);
            var fontsize = ToDouble(document.Attribute("fontsize"));
            //Convert Colors 
            var background = HexBrush(document.Attribute("background").Value);
            var foreground = HexBrush(document.Attribute("foreground").Value);
            var border = HexBrush(document.Attribute("border").Value);
            //Font Family 
            var fontfamily = document.Attribute("fontfamily").Value;
            //Grab the Text 
            var text = document.Element("text").Value;

            //Fill up the ATextField 
            _txt.Text = text;
            _txt.FontFamily = new FontFamily(fontfamily);
            _txt.FontSize = fontsize;
            _txt.Width = width;
            _txt.Height = height;
            _txt.CornerRadius = new CornerRadius(cornerradius);
            _txt.BorderThickness = new Thickness(thickness);
            _txt.Background = background;
            _txt.Foreground = foreground;
            _txt.BorderBrush = border;


            return (xml, _filename);
        }



        #endregion



        public TabControl VMTab
        {
            get;
            set;
        }

    }


}

