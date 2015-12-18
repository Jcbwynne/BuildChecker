using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Json;
using System.Net;
using System.Web.UI.HtmlControls;
using System.IO;

namespace TestWebApp
{
    public partial class _Default : Page
    {
        /*
            Make list of stats affected by items and champ base stuff into object with associated viewstate
            display the stats of that viewstate in the summary panel
            Affect viewstate with all selecteditem stats
            Do this every page_load
        */
        protected void Page_Load(object sender, EventArgs e)
        {

            setupChampList();
            setupItemList();
            //GetMasteries();
            //GetItems();

            SetupViewStates();

            if (!Page.IsPostBack)
            {
                

            }
            else
            {
                if (ViewState["selectedChampion"] != null)
                {
                    CharacterBuild character = ((CharacterBuild)ViewState["CharacterBuild"]);
                    character.champion = ((Champion)ViewState["selectedChampion"]);
                    character.abilitypower = "0";
                    //champStatisticGridView.DataSource = character.champion.stats;
                    //champStatisticGridView.DataBind();
                    if (ViewState["selectedItems"] != null)
                    {
                        List<ItemData> selectedItems = (List<ItemData>)ViewState["selectedItems"];
                        if (selectedItems.Count > 5)
                        {
                            if (File.Exists(Server.MapPath("~/Resources/ITEM" + selectedItems[5].id + ".png")))
                            {
                                ItemSlot6.ImageUrl = "~/Resources/ITEM" + selectedItems[5].id + ".png";
                            }
                            else
                            {
                                ItemSlot6.ImageUrl = "~/Resources/questionmark.png";
                            }
                        }
                        if (selectedItems.Count > 4)
                        {
                            if (File.Exists(Server.MapPath("~/Resources/ITEM" + selectedItems[4].id + ".png")))
                            {
                                ItemSlot5.ImageUrl = "~/Resources/ITEM" + selectedItems[4].id + ".png";
                            }
                            else
                            {
                                ItemSlot5.ImageUrl = "~/Resources/questionmark.png";
                            }
                        }
                        if (selectedItems.Count > 3)
                        {
                            if (File.Exists(Server.MapPath("~/Resources/ITEM" + selectedItems[3].id + ".png")))
                            {
                                ItemSlot4.ImageUrl = "~/Resources/ITEM" + selectedItems[3].id + ".png";
                            }
                            else
                            {
                                ItemSlot4.ImageUrl = "~/Resources/questionmark.png";
                            }
                        }
                        if (selectedItems.Count > 2)
                        {
                            if (File.Exists(Server.MapPath("~/Resources/ITEM" + selectedItems[2].id + ".png")))
                            {
                                ItemSlot3.ImageUrl = "~/Resources/ITEM" + selectedItems[2].id + ".png";
                            }
                            else
                            {
                                ItemSlot3.ImageUrl = "~/Resources/questionmark.png";
                            }
                        }
                        if (selectedItems.Count > 1)
                        {
                            if (File.Exists(Server.MapPath("~/Resources/ITEM" + selectedItems[1].id + ".png")))
                            {
                                ItemSlot2.ImageUrl = "~/Resources/ITEM" + selectedItems[1].id + ".png";
                            }
                            else
                            {
                                ItemSlot2.ImageUrl = "~/Resources/questionmark.png";
                            }
                        }
                        if (selectedItems.Count > 0)
                        {
                            if (File.Exists(Server.MapPath("~/Resources/ITEM" + selectedItems[0].id + ".png")))
                            {
                                ItemSlot1.ImageUrl = "~/Resources/ITEM" + selectedItems[0].id + ".png";
                            }
                            else
                            {
                                ItemSlot1.ImageUrl = "~/Resources/questionmark.png";
                            }
                        }

                        
                    }
                }
                //string controlName = Request.Params.Get("_EVENTTARGET");
            }
            SetupChampStatisticSummary();
        }

        void SetupViewStates()
        {
            if (ViewState["ItemListModTest"] == null)
            {
                ViewState["ItemListModTest"] = new List<ItemModifier>();
            }
            if (ViewState["itemList"] == null)
            {
                List<ItemData> itemList = GetItems();
                foreach (ItemData item in itemList)
                {
                    Table table = new Table();
                    table.CssClass = "Tile";
                    TableRow nameRow = new TableRow();
                    TableRow descriptionRow = new TableRow();
                    TableCell itemDescriptionCell = new TableCell() { Text = item.description };
                    TableCell itemNameCell = new TableCell() { Text = item.name };
                    nameRow.Cells.Add(itemNameCell);
                    descriptionRow.Cells.Add(itemDescriptionCell);
                    table.Rows.Add(nameRow);
                    table.Rows.Add(descriptionRow);
                    itemPanelPopUpTitle.Controls.Add(table);
                }
                ViewState["itemList"] = itemList;
            }

            List<ItemModifier> modList = ViewState["ItemListModTest"] as List<ItemModifier>;
            modList = new List<ItemModifier>();
            foreach (ItemData item in (ViewState["itemList"] as List<ItemData>))
            {
                foreach (string modifier in item.modifier)
                {
                    
                }
            }

            if (ViewState["champList"] == null)
            {
                List<Champion> champList = new List<Champion>();
                champList = GetChampions();
                champList.Sort();
                ViewState["champList"] = champList;
            }

            if (ViewState["CharacterBuild"] == null)
            {
                ViewState["CharacterBuild"] = new CharacterBuild();
            }

            if (ViewState["selectedItems"] == null)
            {
                ViewState["selectedItems"] = new List<ItemData>();
            }
            else
            {
                List<ItemData> selectedItems = ViewState["selectedItems"] as List<ItemData>;
                ViewState["ItemModifierList"] = new List<ItemModifier>();
                CharacterBuild character = ViewState["CharacterBuild"] as CharacterBuild;
                foreach (ItemData item in selectedItems)
                {
                    foreach (string modifier in item.modifier)
                    {
                        ItemModifier itemMod = new ItemModifier();
                        itemMod.itemName = item.name;

                        if (modifier.Contains("Attack Speed"))
                        { }
                        else if (modifier.Contains("Magic Damage on Hit"))
                        { }
                        else if (modifier.Contains("Attack Damage"))
                        { }
                        else if (modifier.Contains("Armor Penetration"))
                        { }
                        else if (modifier.Contains("Cooldown Reduction"))
                        { }
                        else if (modifier.Contains("Ability Power"))
                        { }
                        else if (modifier.Contains("Base Mana Regen while in Jungle"))
                        { }
                        else if (modifier.Contains("Base Mana Regen"))
                        { }
                        else if (modifier.Contains("Mana"))
                        { }
                        else if (modifier.Contains("Critical Strike Chance"))
                        { }
                        else if (modifier.Contains("Movement Speed"))
                        { }
                        else if (modifier.Contains("Gold per"))
                        { }
                        else if (modifier.Contains("Life Steal vs. Monsters"))
                        { }
                        else if (modifier.Contains("Armor"))
                        { }
                        else if (modifier.Contains("Base Health Regen"))
                        { }
                        else if (modifier.Contains("Health Regen"))
                        { }
                        else if (modifier.Contains("Health"))
                        { }
                        else if (modifier.Contains("Life on Hit"))
                        { }
                        else if (modifier.Contains("Magic Resist"))
                        { }
                        else if (modifier.Contains("Mana Regen"))
                        { }
                        else if (modifier.Contains("Increased Healing from Potions"))
                        { }
                        else if (modifier.Contains("Life Steal"))
                        { }
                        else if (modifier.Contains("Damage taken from Critical Strikes"))
                        { }
                        else if (modifier.Contains("Magic Penetration"))
                        { }


                        if (modifier.Contains("Attack Damage"))
                        {
                            itemMod.modifier = "Attack Damage";
                            
                        }
                        else if (modifier.Contains("Magic Damage on Hit"))
                        {

                        }
                        else if (modifier.Contains("Magic Resist"))
                        {
                            itemMod.modifier = "Magic Resist";                        }
                        else if (modifier.Contains("Armor Penetration"))
                        {
                            itemMod.modifier = "Armor Penetration";
                        }
                        else if (modifier.Contains("Attack Speed"))
                        {
                            itemMod.modifier = "Attack Speed";

                        }
                        else if (modifier.Contains("Cooldown Reduction"))
                        {
                            itemMod.modifier = "Cooldown Reduction";
                        }
                        else if (modifier.Contains("Ability Power"))
                        {
                            itemMod.modifier = "Ability Power";

                        }
                        else
                        {
                            List<string> itemmodifiers = new List<string>();
                            itemmodifiers.Add(modifier);
                            ViewState["ItemMiscModifiers"] = itemmodifiers;
                        }
                        (ViewState["ItemModifierList"] as List<ItemModifier>).Add(itemMod);
                    }
                }
                if (ViewState["ItemMiscModifiers"] != null)
                {
                    List<string> modifiers = (List<string>)ViewState["ItemMiscModifiers"];
                    foreach (string modifier in modifiers)
                    {
                        itemmisc.InnerHtml += "<br>" + modifier;
                    }
                }
            }
        }

        public List<ItemData> GetItems()
        {
            List<ItemData> itemList = new List<ItemData>();
            List<ItemData> itemDataTestList = new List<ItemData>();

            JsonParser parser = new JsonParser();
            using (WebClient webClient = new WebClient())
            {
                var json = webClient.DownloadString("https://global.api.pvp.net/api/lol/static-data/na/v1.2/item?itemListData=all&api_key=" + APIKey.Key);
                // ("https://global.api.pvp.net/api/lol/static-data/na/v1.2/item?api_key=" + APIKey.Key);
                

                var jsonobject = JsonParser.Deserialize<ItemCallObject>(json);

                foreach (object item in (jsonobject as ItemCallObject).data)
                {
                    var listitem = (KeyValuePair<string, dynamic>)item;
                    ItemData itemData = new ItemData();
                    itemData.from = new List<string>();
                    itemData.modifier = new List<string>();
                    foreach (object subitem in listitem.Value)
                    {
                        var pairItem = (KeyValuePair<string, dynamic>)subitem;
                        if (pairItem.Key == "id")
                        {
                            itemData.id = pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "name")
                        {
                            itemData.name = (string)pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "description")
                        {
                            itemData.description = (string)pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "plaintext")
                        {
                            itemData.plaintext = (string)pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "group")
                        {
                            itemData.group = (string)pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "maps")
                        {
                            itemData.maps = pairItem.Value;
                        }
                        if (pairItem.Key == "gold")
                        {
                            itemData.gold = ((Dictionary<string, object>)pairItem.Value).First(x => x.Key.ToString() == "total").Value.ToString();
                        }
                        if(pairItem.Key == "depth")
                        {
                            itemData.depth = pairItem.Value.ToString();
                        }
                        if(pairItem.Key == "from")
                        {
                            foreach(var fromitem in pairItem.Value)
                            {
                                itemData.from.Add(fromitem.ToString());
                            }
                        }
                        //TODO get Uniques
                    }

                    if (((Dictionary<string, object>)itemData.maps).First(x => x.Key == "11").Value.ToString() == "True" && itemData.group != "PinkWards" && itemData.group != "Flasks" && itemData.group != "TheBlackSpear" && itemData.group != "RelicBase")
                    {
                        if(itemData.group == "RelicBase")
                        {
                            itemDataTestList.Add(itemData);
                        }
                        itemList.Add(itemData);
                    }
                }
                
                foreach(ItemData item in itemList)
                {
                    if (item.description.Contains("<stats>"))
                    {
                        string modifiertotal = item.description.Substring(item.description.IndexOf("<stats>") + 7, item.description.IndexOf("</stats>") - (item.description.IndexOf("<stats>") + 7));
                        string[] modifiers = modifiertotal.Split(new string[] { "<br>" }, StringSplitOptions.None);
                        foreach (string modifier in modifiers)
                        {
                            if (!string.IsNullOrEmpty(modifier.Trim()))
                            {
                                item.modifier.Add(modifier);
                            }
                        }
                    }
                }
                /*
                //sort by group
                itemList.Sort(delegate (ItemData item1, ItemData item2) 
                {
                    if(item2.group == null)
                    {
                        return 0;
                    }
                    if(item1.group == null)
                    {
                        return 0;
                    }
                    return item1.group.CompareTo(item2.group);
                });
                //filter into group lists
                string lastGroup = String.Empty;
                ViewState["ItemGroupList"] = new List<string>();
                foreach (ItemData item in itemList) 
                {
                    if(item.group == null)
                    {
                        break;
                    }
                    if(item.group != lastGroup)
                    {
                        ViewState["ItemGroup" + item.group] = new List<ItemData>();
                        lastGroup = item.group;
                        ((List<string>)ViewState["ItemGroupList"]).Add(item.group);
                    }
                    ((List<ItemData>)ViewState["ItemGroup" + item.group]).Add(item);
                }

                //sort by depth
                foreach(string group in ((List<string>)(ViewState["ItemGroupList"])))
                {
                    ((List<ItemData>)ViewState["ItemGroup" + group]).Sort(delegate (ItemData item1, ItemData item2) { return item1.depth.CompareTo(item2.depth); });
                }

                //viewstate with int for each list of group
                */
                return itemList;
            }
        }

        public List<Champion> GetChampions()
        {
            List<Champion> champlist = new List<Champion>();
            JsonParser parser = new JsonParser();
            using (WebClient webClient = new WebClient())
            {
                var json = webClient.DownloadString("https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion?champData=stats&api_key=" + APIKey.Key);
                //("https://na.api.pvp.net/api/lol/na/v1.2/champion?api_key=" + APIKey.Key);

                var jsonobject = JsonParser.Deserialize<Champions>(json);

                foreach (object item in (jsonobject as Champions).data)
                {
                    var listitem = (KeyValuePair<string, dynamic>)item;
                    Champion champion = new Champion();
                    foreach (object subitem in listitem.Value)
                    {
                        var pairItem = (KeyValuePair<string, dynamic>)subitem;
                        //var pairItem = (KeyValuePair<string, string>)subitem;
                        if (pairItem.Key == "id")
                        {
                            champion.id = pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "key")
                        {
                            champion.key = (string)pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "name")
                        {
                            champion.name = (string)pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "title")
                        {
                            champion.title = (string)pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "stats")
                        {
                            champion.stats = new Stats();
                            foreach (var statItem in pairItem.Value)
                            {
                                var statPairItem = (KeyValuePair<string, dynamic>)statItem;
                                if (statPairItem.Key == "armor")
                                {
                                    champion.stats.armor = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "armorperlevel")
                                {
                                    champion.stats.armorperlevel = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "attackdamage")
                                {
                                    champion.stats.attackdamage = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "attackdamageperlevel")
                                {
                                    champion.stats.attackdamageperlevel = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "attackrange")
                                {
                                    champion.stats.attackrange = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "attackspeedoffset")
                                {
                                    champion.stats.attackspeedoffset = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "attackspeedperlevel")
                                {
                                    champion.stats.attackspeedperlevel = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "crit")
                                {
                                    champion.stats.crit = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "critperlevel")
                                {
                                    champion.stats.critperlevel = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "hp")
                                {
                                    champion.stats.hp = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "hpperlevel")
                                {
                                    champion.stats.hpperlevel = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "hpregen")
                                {
                                    champion.stats.hpregen = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "hpregenperlevel")
                                {
                                    champion.stats.hpregenperlevel = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "movespeed")
                                {
                                    champion.stats.movespeed = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "mp")
                                {
                                    champion.stats.mp = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "mpperlevel")
                                {
                                    champion.stats.mpperlevel = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "mpregen")
                                {
                                    champion.stats.mpregen = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "mpregenperlevel")
                                {
                                    champion.stats.mpregenperlevel = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "spellblock")
                                {
                                    champion.stats.spellblock = statPairItem.Value.ToString();
                                }
                                if (statPairItem.Key == "spellblockperlevel")
                                {
                                    champion.stats.spellblockperlevel = statPairItem.Value.ToString();
                                }
                            }
                        }
                    }

                    champlist.Add(champion);
                }
                return champlist;
            }
        }

        public List<Mastery> GetMasteries()
        {
            List<Mastery> masteryList = new List<Mastery>();

            JsonParser parser = new JsonParser();
            using (WebClient webClient = new WebClient())
            {
                var json = webClient.DownloadString("https://global.api.pvp.net/api/lol/static-data/na/v1.2/mastery?masteryListData=masteryTree&api_key=" + APIKey.Key);
                
                var jsonobject = JsonParser.Deserialize<MasteryObject>(json);
                foreach(object item in jsonobject.data)
                {
                    Mastery mastery = new Mastery();

                    var listitem = (KeyValuePair<string, dynamic>)item;
                    foreach (var subItem in listitem.Value)
                    {
                        var pairItem = (KeyValuePair<string, dynamic>)subItem;
                        if (pairItem.Key == "id")
                        {
                            mastery.id = pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "name")
                        {
                            mastery.name = (string)pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "description")
                        {
                            mastery.description = (string)pairItem.Value[0].ToString();
                        }
                        if (pairItem.Key == "masteryTree")
                        {
                            mastery.masteryTree = (string)pairItem.Value.ToString();
                        }
                    }
                    masteryList.Add(mastery);
                }
            }

            return masteryList;
        }

        public List<Rune> GetRunes()
        {
            List<Rune> runeList = new List<Rune>();

            //ViewState list by type?
            //quint
            //yellow
            //red
            //blue

            JsonParser parser = new JsonParser();
            using (WebClient webClient = new WebClient())
            {
                var json = webClient.DownloadString("https://global.api.pvp.net/api/lol/static-data/na/v1.2/rune?api_key=" + APIKey.Key);

                var jsonobject = JsonParser.Deserialize<MasteryObject>(json);
                foreach (object item in jsonobject.data)
                {
                    Rune rune = new Rune();
                    rune.rune = new RuneTierInfo();

                    var listitem = (KeyValuePair<string, dynamic>)item;
                    foreach (var subItem in listitem.Value)
                    {
                        var pairItem = (KeyValuePair<string, dynamic>)subItem;
                        if (pairItem.Key == "id")
                        {
                            rune.id = pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "name")
                        {
                            rune.name = pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "description")
                        {
                            rune.description = pairItem.Value.ToString();
                        }
                        if (pairItem.Key == "rune")
                        {
                            foreach (var runeitem in pairItem.Value)
                            {
                                var runelistitem = (KeyValuePair<string, dynamic>)runeitem;
                                if (runelistitem.Key == "isRune")
                                {
                                    rune.rune.isRune = runelistitem.Value.ToString();
                                }
                                if (runelistitem.Key == "tier")
                                {
                                    rune.rune.tier = runelistitem.Value.ToString();
                                }
                                if (runelistitem.Key == "type")
                                {
                                    rune.rune.type = runelistitem.Value.ToString();
                                }
                            }
                            //probably parse this out for tier3 then only add to runelist on tier3==true
                        }
                    }
                    if (rune.rune.tier == "3")
                    {
                        runeList.Add(rune);
                    }
                }
            }
            return runeList;
        }

        /*
        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            if(sender is TextBox)
            {
                if(ViewState["champList"] != null)
                {
                    List<Champion> champlist = (List<Champion>)ViewState["champList"];
                    List<Champion> tempList = new List<Champion>();
                    TextBox textbox = (TextBox)sender;
                    string text = textbox.Text;
                    if (textbox.ID == "txtName")
                    {
                        tempList = champlist.Where(x => x.name.Trim().ToUpper().Contains(textbox.Text.Trim().ToUpper())).ToList();
                        foreach (Champion item in tempList)
                        {
                            
                            Table table = new Table();
                            //table.Attributes.Add("onClick", string.Format("javascript:__doPostBack('{0}','')", this.UniqueID));
                            table.CssClass = "Tile roundedcorners";
                            
                            TableRow nameRow = new TableRow();
                            //TableRow imageRow = new TableRow();
                            //TableCell imageCell = new TableCell() ;
                            TableCell itemNameCell = new TableCell() { Text = item.name };
                            nameRow.Cells.Add(itemNameCell);
                            //imageRow.Cells.Add(imageCell);
                            table.Rows.Add(nameRow);
                            //table.Rows.Add(imageRow);
                            championPanelPopUpTitle.Controls.Add(table);
                        }
                    }
                    textbox.Text = text;
                }
            }
        }
        */
        protected void showChamps_Click(object sender, EventArgs e)
        {
            championPanelOverlay.Visible = true;
            championPanelPopUpTitle.Visible = true;
            championPopupQuit.Visible = true;
            championgPanelPopUpPanel.Visible = true;

            setupChampList();

        }

        protected void hideChamps_Click(object sender, EventArgs e)
        {
            championPanelOverlay.Visible = false;
            championPanelPopUpTitle.Visible = false;
            championPopupQuit.Visible = false;
            championgPanelPopUpPanel.Visible = false;

            //setupChampList();
        }

        protected void showItems_Click(object sender, EventArgs e)
        {
            itemPanelOverlay.Visible = true;
            itempanelPopUpPanel.Visible = true;
            itemPopupQuit.Visible = true;
            //championPanel.Visible = true;
            List<ItemData> itemList = GetItems();

            /*
            

            PlaceHolder1.Controls.Add(newControl);
            */



            //foreach (ItemData item in itemList)
            {
                /*
                HtmlGenericControl newControl = new HtmlGenericControl("input");
                newControl.ID = "NEWControl" + Index;
                newControl.InnerHtml = item.name + "\n" + item.description;
                newControl.Attributes["class"] = "Tile";
                newControl.Attributes["class"] = "submit";
                newControl.Attributes["onclick"] = string.Format("__doPostBack('{0}', '{1}');", newControl.ClientID, "SomeArgument");
                /*
                Table table = new Table();
                table.CssClass = "Tile roundedcorners";
                TableRow nameRow = new TableRow();
                TableRow descriptionRow = new TableRow();
                TableCell itemDescriptionCell = new TableCell() { Text = item.description };
                TableCell itemNameCell = new TableCell() { Text = item.name };
                nameRow.Cells.Add(itemNameCell);
                descriptionRow.Cells.Add(itemDescriptionCell);
                table.Rows.Add(nameRow);
                table.Rows.Add(descriptionRow);
                
                

                
                */
                //itemPanelPopUpTitle.Controls.Add(newControl);
            }


            ViewState["itemList"] = itemList;
        }

        protected void hideItems_Click(object sender, EventArgs e)
        {
            itemPanelOverlay.Visible = false;
            itempanelPopUpPanel.Visible = false;
            itemPopupQuit.Visible = false;
        }

        protected void showChampPopup(bool b)
        {
            championPanelOverlay.Visible = b;
            championgPanelPopUpPanel.Visible = b;
            championPopupQuit.Visible = b;
        }

        protected void pickItem_Click(object sender, GridViewCommandEventArgs e)
        {
            List<ItemData> selectedItems = ((List<ItemData>)ViewState["selectedItems"]);
            if (selectedItems.Count < 6)
            {
                string id = e.CommandArgument.ToString();
                ItemData item = ((List<ItemData>)ViewState["itemList"]).Find(x => x.id == id);
                selectedItems.Add(item);
                ViewState["selectedItems"] = selectedItems;
            }
        }

        protected void championGridView_Command(object sender, CommandEventArgs e)
        {
            
            string id = e.CommandArgument.ToString();

            Champion champ = ((List<Champion>)ViewState["champList"]).Find(x => x.id == id);
            ViewState["selectedChampion"] = champ;

            hideChamps_Click(null, null);
        }

        public void setupItemList()
        {
            if ((List<ItemData>)ViewState["itemList"] != null)
            {
                List<ItemData> itemList = (List<ItemData>)ViewState["itemList"];
                foreach (ItemData item in itemList)
                {
                    HtmlGenericControl newControl = new HtmlGenericControl("div");
                    newControl.ID = "NEWControl" + Index;
                    //newControl.InnerHtml = item.name;
                    newControl.Attributes["class"] = "Tile";

                    ImageButton button = new ImageButton();
                    if (File.Exists(Server.MapPath("~/Resources/ITEM" + item.id + ".png")))
                    {
                        button.ImageUrl = "~/Resources/ITEM" + item.id + ".png";
                    }
                    else
                    {
                        button.ImageUrl = "~/Resources/questionmark.png";
                    }
                    button.ID = item.id;
                    button.Click += new ImageClickEventHandler(ItemButton_Click);
                    button.CssClass = "itemImageButton";
                    newControl.Controls.Add(button);

                    Label label = new Label();
                    label.Text = item.gold;
                    newControl.Controls.Add(label);
                    //add text to controls newControl.InnerHtml = item.gold;
                    itemPanelPopUpTitle.Controls.Add(newControl);



                    /*
                    Table table = new Table();
                    table.CssClass = "Tile";
                    TableRow nameRow = new TableRow();
                    TableRow descriptionRow = new TableRow();
                    TableCell itemDescriptionCell = new TableCell() { Text = item.description };
                    TableCell itemNameCell = new TableCell() { Text = item.name };
                    nameRow.Cells.Add(itemNameCell);
                    descriptionRow.Cells.Add(itemDescriptionCell);
                    table.Rows.Add(nameRow);
                    table.Rows.Add(descriptionRow);
                    itemPanelPopUpTitle.Controls.Add(table);*/
                }
            }
        }

        public void setupChampList()
        {
            if ((List<Champion>)ViewState["champList"] != null)
            {
                List<Champion> champList = (List<Champion>)ViewState["champList"];

                foreach (Champion item in champList)
                {
                    HtmlGenericControl newControl = new HtmlGenericControl("div");
                    newControl.ID = "NEWControl" + Index;
                    //newControl.InnerHtml = item.name;
                    newControl.Attributes["class"] = "Tile";

                    ImageButton button = new ImageButton();
                    if (File.Exists(Server.MapPath("~/Resources/" + item.name + ".png")))
                    {
                        try
                        {
                            button.ImageUrl = "~/Resources/" + item.name + ".png";
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        button.ImageUrl = "~/Resources/Face.png";
                    }
                    button.ID = item.id;
                    button.Click += new ImageClickEventHandler(ChampButton_Click);
                    button.CssClass = "champImageButton";
                    newControl.Controls.Add(button);
                    championPanelPopUpTitle.Controls.Add(newControl);
                }
            }
        }

        protected void ChampButton_Click(object sender, EventArgs e)
        {
            string id = ((ImageButton)sender).ID;
            Champion champ = ((List<Champion>)ViewState["champList"]).Find(x => x.id == id);
            ViewState["selectedChampion"] = champ;

            CharacterBuild character = ((CharacterBuild)ViewState["CharacterBuild"]);
            character.champion = ((Champion)ViewState["selectedChampion"]);
            selectedChamp.Text = ((Champion)ViewState["selectedChampion"]).name;
            hideChamps_Click(null, null);

            Page_Load(null, null);
        }

        protected void ItemButton_Click(object sender, EventArgs e)
        {
            string id = ((ImageButton)sender).ID;
            ItemData item = ((List<ItemData>)ViewState["itemList"]).Find(x => x.id == id);
            ((List<ItemData>)ViewState["selectedItems"]).Add(item);

            CharacterBuild character = ((CharacterBuild)ViewState["CharacterBuild"]);
            character.items = ((List<ItemData>)ViewState["selectedItems"]);
            hideItems_Click(null, null);

            Page_Load(null, null);
        }

        public void SetupChampStatisticSummary()
        {
            
            if (((CharacterBuild)ViewState["CharacterBuild"]).champion != null)
            {
                abilitypower.InnerHtml = "Ability Power: " + ((CharacterBuild)ViewState["CharacterBuild"]).abilitypower;

                Champion champion = ((CharacterBuild)ViewState["CharacterBuild"]).champion;

                armor.InnerHtml = "Armor: " + champion.stats.armor;
                
                armorperlevel.InnerHtml = "Armor Per Level: " + champion.stats.armorperlevel;

                attackdamage.InnerHtml = "Attack Damage: " + champion.stats.attackdamage;

                attackdamageperlevel.InnerHtml = "Attack Damage Per Level: " + champion.stats.attackdamageperlevel;

                attackrange.InnerHtml = "Attack Range: " + champion.stats.attackrange;

                attackspeedoffset.InnerHtml = "Attack Speed: " + champion.stats.attackspeedoffset;

                attackspeedperlevel.InnerHtml = "Attack Speed Per Level: " + champion.stats.attackspeedperlevel;

                crit.InnerHtml = "Critical Chance: " + champion.stats.crit;

                critperlevel.InnerHtml = "Critical Chance Per Level: " + champion.stats.critperlevel;

                hp.InnerHtml = "HP: " + champion.stats.hp;

                hpperlevel.InnerHtml = "HP Per Level: " + champion.stats.hpperlevel;

                hpregen.InnerHtml = "HP Regen: " + champion.stats.hpregen;

                hpregenperlevel.InnerHtml = "HP Regen Per Level: " + champion.stats.hpregenperlevel;

                movespeed.InnerHtml = "Movespeed: " + champion.stats.movespeed;

                mp.InnerHtml = "MP: " + champion.stats.mp;

                mpperlevel.InnerHtml = "MP Per Level: " + champion.stats.mpperlevel;

                mpregen.InnerHtml = "MP Regen: " + champion.stats.mpregen;

                mpregenperlevel.InnerHtml = "MP Regen Per Level: " + champion.stats.mpregenperlevel;

                spellblock.InnerHtml = "Magic Resist: " + champion.stats.spellblock;

                spellblockperlevel.InnerHtml = "Magic Resist Per Level: " + champion.stats.spellblockperlevel;
                
            }
        }

        public int Index
        {
            get
            {
                if (ViewState["Index"] == null)
                {
                    ViewState["Index"] = 0;
                }
                else
                {
                    ViewState["Index"] = int.Parse(ViewState["Index"].ToString()) + 1;
                }

                return int.Parse(ViewState["Index"].ToString());
            }
        }

        // utility method to recursively find controls matching a predicate
        IEnumerable<Control> FindRecursive(Control c, Func<Control, bool> predicate)
        {
            if (predicate(c))
                yield return c;

            foreach (var child in c.Controls)
            {
                if (predicate(c))
                    yield return c;
            }

            foreach (var child in c.Controls)
                foreach (var match in FindRecursive(c, predicate))
                    yield return match;
        }
    }
}


/*
int baseAD = 0;
int.TryParse(character.champion.stats.attackdamage, out baseAD);
int modAD = 0;
int.TryParse(modifier.Substring(1, modifier.IndexOf(" ") - 1), out modAD);
character.champion.stats.attackdamage += (baseAD + modAD).ToString();
*/
//character.champion.stats.attackdamage += " + " + modifier.Substring(1, modifier.IndexOf(" ") - 1);
//character.champion.stats.attackdamage += " + " + modifier.Substring(1, modifier.IndexOf(" ") - 1);

//character.champion.stats.attackspeedoffset += " + " + modifier.Substring(1, modifier.IndexOf(" ") - 1);
//character.champion.stats.attackdamage += " + " + modifier.Substring(1, modifier.IndexOf(" ") - 1);

//character.champion.stats.attackdamage += " + " + modifier.Substring(1, modifier.IndexOf(" ") - 1);

/*
int baseAP = 0;
int.TryParse(character.abilitypower, out baseAP);
int modAP = 0;
int.TryParse(modifier.Substring(1, modifier.IndexOf(" ") - 1), out modAP);
character.abilitypower += (baseAP + modAP).ToString();
*/


/*
HtmlGenericControl armor = new HtmlGenericControl("div");
armor.ID = "NEWControl" + Index;
armor.InnerHtml = "Armor: " + champion.stats.armor;
champStatisticPanel.Controls.Add(armor);
//newControl.Attributes["class"] = "Tile";

HtmlGenericControl armorperlevel = new HtmlGenericControl("div");
armorperlevel.ID = "NEWControl" + Index;
armorperlevel.InnerHtml = "Armor Per Level: " + champion.stats.armorperlevel;
champStatisticPanel.Controls.Add(armorperlevel);

HtmlGenericControl attackdamage = new HtmlGenericControl("div");
attackdamage.ID = "NEWControl" + Index;
attackdamage.InnerHtml = "Attack Damage: " + champion.stats.attackdamage;
champStatisticPanel.Controls.Add(attackdamage);

HtmlGenericControl attackdamageperlevel = new HtmlGenericControl("div");
attackdamageperlevel.ID = "NEWControl" + Index;
attackdamageperlevel.InnerHtml = "Attack Damage Per Level: " + champion.stats.attackdamageperlevel;
champStatisticPanel.Controls.Add(attackdamageperlevel);

HtmlGenericControl attackrange = new HtmlGenericControl("div");
attackrange.ID = "NEWControl" + Index;
attackrange.InnerHtml = "Attack Range: " + champion.stats.attackrange;
champStatisticPanel.Controls.Add(attackrange);

HtmlGenericControl attackspeedoffset = new HtmlGenericControl("div");
attackspeedoffset.ID = "NEWControl" + Index;
attackspeedoffset.InnerHtml = "Attack Speed: " + champion.stats.attackspeedoffset;
champStatisticPanel.Controls.Add(attackspeedoffset);

HtmlGenericControl attackspeedperlevel = new HtmlGenericControl("div");
attackspeedperlevel.ID = "NEWControl" + Index;
attackspeedperlevel.InnerHtml = "Attack Speed Per Level: " + champion.stats.attackspeedperlevel;
champStatisticPanel.Controls.Add(attackspeedperlevel);

HtmlGenericControl crit = new HtmlGenericControl("div");
crit.ID = "NEWControl" + Index;
crit.InnerHtml = "Critical Chance: " + champion.stats.crit;
champStatisticPanel.Controls.Add(crit);

HtmlGenericControl critperlevel = new HtmlGenericControl("div");
critperlevel.ID = "NEWControl" + Index;
critperlevel.InnerHtml = "Critical Chance Per Level: " + champion.stats.critperlevel;
champStatisticPanel.Controls.Add(critperlevel);

HtmlGenericControl hp = new HtmlGenericControl("div");
hp.ID = "NEWControl" + Index;
hp.InnerHtml = "HP: " + champion.stats.hp;
champStatisticPanel.Controls.Add(hp);

HtmlGenericControl hpperlevel = new HtmlGenericControl("div");
hpperlevel.ID = "NEWControl" + Index;
hpperlevel.InnerHtml = "HP Per Level: " + champion.stats.hpperlevel;
champStatisticPanel.Controls.Add(hpperlevel);

HtmlGenericControl hpregen = new HtmlGenericControl("div");
hpregen.ID = "NEWControl" + Index;
hpregen.InnerHtml = "HP Regen: " + champion.stats.hpregen;
champStatisticPanel.Controls.Add(hpregen);

HtmlGenericControl hpregenperlevel = new HtmlGenericControl("div");
hpregenperlevel.ID = "NEWControl" + Index;
hpregenperlevel.InnerHtml = "HP Regen Per Level: " + champion.stats.hpregenperlevel;
champStatisticPanel.Controls.Add(hpregenperlevel);

HtmlGenericControl movespeed = new HtmlGenericControl("div");
movespeed.ID = "NEWControl" + Index;
movespeed.InnerHtml = "Movespeed: " + champion.stats.movespeed;
champStatisticPanel.Controls.Add(movespeed);

HtmlGenericControl mp = new HtmlGenericControl("div");
mp.ID = "NEWControl" + Index;
mp.InnerHtml = "MP: " + champion.stats.mp;
champStatisticPanel.Controls.Add(mp);

HtmlGenericControl mpperlevel = new HtmlGenericControl("div");
mpperlevel.ID = "NEWControl" + Index;
mpperlevel.InnerHtml = "MP Per Level: " + champion.stats.mpperlevel;
champStatisticPanel.Controls.Add(mpperlevel);

HtmlGenericControl mpregen = new HtmlGenericControl("div");
mpregen.ID = "NEWControl" + Index;
mpregen.InnerHtml = "MP Regen: " + champion.stats.mpregen;
champStatisticPanel.Controls.Add(mpregen);

HtmlGenericControl mpregenperlevel = new HtmlGenericControl("div");
mpregenperlevel.ID = "NEWControl" + Index;
mpregenperlevel.InnerHtml = "MP Regen Per Level: " + champion.stats.mpregenperlevel;
champStatisticPanel.Controls.Add(mpregenperlevel);

HtmlGenericControl spellblock = new HtmlGenericControl("div");
spellblock.ID = "NEWControl" + Index;
spellblock.InnerHtml = "Magic Resist: " + champion.stats.spellblock;
champStatisticPanel.Controls.Add(spellblock);

HtmlGenericControl spellblockperlevel = new HtmlGenericControl("div");
spellblockperlevel.ID = "NEWControl" + Index;
spellblockperlevel.InnerHtml = "Magic Resist Per Level: " + champion.stats.spellblockperlevel;
champStatisticPanel.Controls.Add(spellblockperlevel);
*/
