using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Style;
using Dalamud.Interface.Textures;
using Dalamud.Interface.Utility.Raii;
using Dalamud.Interface.Windowing;
using Dalamud.Utility;
using Dalamud.Bindings.ImGui;
using Lumina.Excel.Sheets;
using XIVCombo.Attributes;
using XIVCombo.Combos;
using Action = Lumina.Excel.Sheets.Action;
using Language = Lumina.Data.Language;

namespace XIVCombo.Interface;

/// <summary>
/// Plugin configuration window.
/// </summary>
public class ConfigWindow : Window
{
    bool themePushed = false;
	StyleModel pluginStyle = StyleModel.Deserialize("DS1H4sIAAAAAAAACqVYy3LbNhT9lQ7XHg/xBrSL7TZexB1P7E7a7GiKlljTokpRzsOTf8/FG6AkT6R6IwPCObjve6HXoipm6Lw8Kx6K2WvxNyxKvfqnmMnz8sdZURczrDfm7ljjjpXnzJyCTzj1CN+eFQt3dunOtm5dPbiNfx2YuyuIueLJHevcqefJKWpOrSa73Oz2bpdmZ9dBSLtbmt3/ipnSGwPcA8qdFRt38Qgb5p+t23hxn1/c51cn2be9yn/fe1tVuW2SKVv3oOZrcd98HQNMMKwowg4ssaAMrPlZLxQvhaTkrPhkRAACjbxqN9VD18wDA2elkiV1DFxDEHUUZkEETTg+tat5/+ViEQWH+5HgXqu4NAyIGnqWMFwu225+GoE1z22/3q4TAn2cipI7gri0BLIkCiOeSHDRD/NmiDY0AOTgIrteCcyocpcDa0k5Cgx3ywpssetChy0Tmf8YqucmlZlxybHwSiMtMZPKIbGWmHGVyOwIrvuXZki8R5gqCcbC8YCviJLE0VAlCOZ4l+VdPbYvMR0xlxBHxHFgWUpKheMgigmMUknu27HLVDEGo9KrYiISSa+KDknw4C7BRIij48jRXPZdV603iU2OZrppVtuLakh1MvaX3qwo5JLViZu/VKe7egA5HjKSt+IhnH8/6BLnHZHlIrguSWdCVQlypN7MSKaRYTIXM28Fq7VPbObLxn6uiWuQSYLSV5mYUZ8zMZMMb+qnm2p4OjbFnChdC8mVGeZE/ESPo1gutuPY+84BWqIMHMPaOkcblyiyg9/J12A76xXL6r1iqoCvNky7u5SBaqIMZbxUigQmVcoSYeyouMBKsjRCr5sqLXpHJ4nFT/U52iyWZqILwQJz5AsQgRorFApVjIJjBE9J7pp1NVRjH9UheT0lWQswtVViuo9hqtBxkeZZJvqokgpKPYlkSFLmPaMEVJZUlI/Npv3evB/a9al1IDLstgcEkug4sGbhRCoqvSjOsPupJioxIgQmnohRKQn3cctJSQgSWXFOq9qxMQLgnThTUknMQoggIcEZQRGEoQnirMnsZD/EBFEoUFDwkSTY+5ZRVHKsW2dK8dfqsa+3aXM5RZnAMrUpxUiS4GeBSiHi+AbRTLiWL1Bd9fVTu1rcDs1L28S5A/saoEuHxVpLAGVE/f68Hr8l3clXc2/DNApuu3780K6aTZwSvcL6H+t0tA+Q+81MvtbaPpsJm8Cu283YL2AuiSmYjXNZ8KukQu6hmEaNpByKie/iYFsqoLQELg7W57mrusYWqP8z4BoaNyGOQ79aHKtZWvsTsg/tYjmeUPH0jA8Lwpjn+5hP8G/MKfH4u26ceBU5BIoI7l4Zd03X1GOTjvlvRCnRgl0N1eJq6Nf31bBoDl0VhVMA+bN6uQabdJldDt5jnQMY+4SBlJiCDysmJsir9jlRzVdFXwW8XljPlv286izu10BgDP1khTm9mBWX1bheb+u6Xf1209fLqoDXtH0F+ieiLhQmIn2U5+O3dXxaj2Jdtm8OeeDpZ0fetFHVsXDlcZyNg6GBBlzMRxfWeyXlxKzTC5PJzb+HfuWZ+xhhZorX3dYVADf1WoN7fQMwOieQWgWzTKWmxOtJKwCXSUlPa0VuUhUyNgDbA89wqedtpMJgaN/hKdL/HgK0xPwFN3p7Tqfyp0MIaV8KEWg8kVq0O602P5/eNVcnG6Y/1Rdx/DpKSfhp6LSgicNrDpzMnD5lAi425aiEs41Jdq+iND8igKUcEqDQHeGbHz8BRb7GJboTAAA=");
    //     Code to be executed before conditionals are applied and the window is drawn.
	public override void PreDraw()
	{
		if (Service.Configuration.EnableTheme && themePushed == false)
		{
			pluginStyle.Push();
            themePushed = true;
		}
	}

	//     Code to be executed after the window is drawn.
	public override void PostDraw()
	{
		if (themePushed == true)
		{
			pluginStyle.Pop();
			themePushed = false;
		}

	}

	private readonly Dictionary<string, List<(CustomComboPreset Preset, CustomComboInfoAttribute Info)>> groupedPresets;
	private readonly Dictionary<CustomComboPreset, (CustomComboPreset Preset, CustomComboInfoAttribute Info)[]> presetChildren;
	private readonly Vector4 shadedColor = new(0.68f, 0.68f, 0.68f, 1.0f);
	private XIVCombo Plugin;

	/// <summary>
	/// Initializes a new instance of the <see cref="ConfigWindow"/> class.
	/// </summary>
	public ConfigWindow(XIVCombo Plugin)
	: base($"XIVCombo v{Service.Interface.Manifest.AssemblyVersion}")
	{
		this.Plugin = Plugin;
		this.RespectCloseHotkey = true;
		this.groupedPresets = Enum
		.GetValues<CustomComboPreset>()
		.Where(preset => (int)preset > 100 && preset != CustomComboPreset.Disabled)
		.Select(preset => (Preset: preset, Info: preset.GetAttribute<CustomComboInfoAttribute>()))
		.Where(tpl => tpl.Info != null && Service.Configuration.GetParent(tpl.Preset) == null)
		.OrderBy(tpl => CustomComboInfoAttribute.RoleIDToOrder(tpl.Info.RoleName))
		.ThenBy(tpl => tpl.Info.JobID)
		.ThenBy(tpl => tpl.Info.Order)
		.ThenBy(tpl => tpl.Preset.GetAttribute<SectionComboAttribute>()?.Section)
		.GroupBy(tpl => tpl.Info.JobName)
		.ToDictionary(
		tpl => tpl.Key,
		tpl => tpl.ToList());
		var childCombos = Enum.GetValues<CustomComboPreset>().ToDictionary(
		tpl => tpl,
		tpl => new List<CustomComboPreset>());
		foreach (var preset in Enum.GetValues<CustomComboPreset>())
		{
			var parent = preset.GetAttribute<ParentComboAttribute>()?.ParentPreset;
			if (parent != null)
				childCombos[parent.Value].Add(preset);
		}
		this.presetChildren = childCombos.ToDictionary(
		kvp => kvp.Key,
		kvp => kvp.Value
		.Select(preset => (Preset: preset, Info: preset.GetAttribute<CustomComboInfoAttribute>()))
		.OrderBy(tpl => tpl.Info.Order).ToArray());
		this.SizeCondition = ImGuiCond.FirstUseEver;
		this.Size = new Vector2(750, 500);
		WindowSizeConstraints windowSizeConstraints = new WindowSizeConstraints();
		if (Service.Configuration.BigComboIcons || Service.Configuration.BigJobIcons)
			windowSizeConstraints.MinimumSize = new Vector2(900, 700);
		else
			windowSizeConstraints.MinimumSize = new Vector2(750, 500);
		this.SizeConstraints = windowSizeConstraints;
	}

	/// <inheritdoc/>
	public override void Draw()
	{
		using (var generalTabs = ImRaii.TabBar("Tabs"))
		{
			if (generalTabs)
			{

				#region COMBOS TAB
				using (var combosTab = ImRaii.TabItem("Combos"))
				{
					if (combosTab)
					{
						// This is cursed. I'm lazy. Don't judge me. Or do. I don't care. It's imgui anyway.
						if (!(Service.Configuration.CurrentJobTab is "Adventurer" or "Disciples of the Land" or "Paladin" or "Monk" or "Warrior" or "Dragoon" or "Bard" or "White Mage"
						or "Black Mage" or "Summoner" or "Scholar" or "Ninja" or "Machinist" or "Dark Knight" or "Astrologian"
						or "Samurai" or "Red Mage" or "Gunbreaker" or "Dancer" or "Reaper" or "Sage" or "Viper" or "Pictomancer"))
                        {
                            Service.Configuration.CurrentJobTab = "Adventurer";
                            Service.Configuration.Save();
                        }

                        float scale = 1f;
                        if (Service.Configuration.BigJobIcons)
                            scale = 1.5f;
                        if (ImGui.BeginChild("TabButtons", new System.Numerics.Vector2(36f * scale, 0f), false, ImGuiWindowFlags.NoScrollbar))
                        {
                            ImGui.SameLine(1f);

                            using (ImRaii.PushStyle(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(4f, 3f)))
                            {
                                if (ImGui.BeginTable("TabButtonsTable", 1, ImGuiTableFlags.None, new System.Numerics.Vector2(36f * scale, 36f * scale), 4f * scale))
                                {
                                    if ((Service.Configuration.CurrentJobTab == "Adventurer"
                                        || Service.Configuration.CurrentJobTab == "Disciples of the Land"
                                        || Service.Configuration.CurrentJobTab == "Sage"))
                                    {
                                        Service.Configuration.CurrentJobTab = "Paladin";
                                    }

                                    foreach (var jobName in this.groupedPresets.Keys)
                                    {
                                        if (jobName is not "Adventurer" and not "Disciples of the Land" and not "Sage")
                                        {
                                            ImGui.TableNextRow();
                                            ImGui.TableNextColumn();
                                            ImGui.PushID($"EditorTab{CustomComboInfoAttribute.NameToJobID(jobName)}");
                                            bool selected = Service.Configuration.CurrentJobTab == jobName ? true : false;

                                            using (selected ? ImRaii.PushColor(ImGuiCol.Button, ImGuiColors.DalamudGrey2) : ImRaii.PushColor(ImGuiCol.Button, 0))
                                            using (selected ? ImRaii.PushColor(ImGuiCol.Border, ImGuiColors.DalamudGrey3) : ImRaii.PushColor(ImGuiCol.Border, 0))
                                            using (ImRaii.PushStyle(ImGuiStyleVar.FramePadding, new System.Numerics.Vector2(4f, 3f)))
                                            using (ImRaii.PushStyle(ImGuiStyleVar.FrameBorderSize, 0))
                                            {
                                                ISharedImmediateTexture image = GetJobIcon(CustomComboInfoAttribute.NameToJobID(jobName));

                                                if (image != null)
                                                {
                                                    if (ImGui.ImageButton(image.GetWrapOrEmpty().Handle, new System.Numerics.Vector2(28f * scale, 28f * scale)))
                                                    {
                                                        Service.Configuration.CurrentJobTab = jobName;
                                                    }

                                                    if (ImGui.IsItemHovered())
                                                    {
                                                        ImGui.BeginTooltip();
                                                        ImGui.TextUnformatted(jobName);
                                                        ImGui.EndTooltip();
                                                    }
                                                }
                                            }

                                            ImGui.PopID();
                                        }
                                    }

                                    ImGui.EndTable();
                                }
                            }

                            ImGui.EndChild();
                        }

                        ImGui.SameLine();

                        ImGui.BeginGroup();

                        ImGui.Indent(-10f);
                        if (ImGui.BeginChild("TabContent", new Vector2(0, -1), true, ImGuiWindowFlags.NoBackground))
                        {
                            #region COMBOS TAB HEADER
                            var jobID = CustomComboInfoAttribute.NameToJobID(Service.Configuration.CurrentJobTab);
                            var image = GetJobIcon(jobID);
                            ImGui.Image(image.GetWrapOrEmpty().Handle, new System.Numerics.Vector2(36f, 36f));
                            ImGui.SameLine();
                            using (ImRaii.PushFont(UiBuilder.MonoFont))
                            using (ImRaii.PushColor(ImGuiCol.Text, ImGuiColors.ParsedGold))
                            {
                                ImGui.Text($" " + Service.Configuration.CurrentJobTab + "\n " + (CustomComboInfoAttribute.JobIDToRole(jobID) != "Adventurer" ? CustomComboInfoAttribute.JobIDToRole(jobID) : "Warrior of Light"));
                            }

							#endregion

							if (Service.Configuration.CurrentJobTab != "Adventurer" && Service.Configuration.CurrentJobTab != "Disciples of the Land" && Service.Configuration.CurrentJobTab != "Sage")
							{
								ImGui.BeginChild("scrolling", new Vector2(0, -1), true);

								int i = 1;
								string previousSection = string.Empty;
								foreach (var (preset, info) in this.groupedPresets[Service.Configuration.CurrentJobTab])
								{
									previousSection = this.DrawPreset(preset, info, previousSection, ref i);
								}

								ImGui.EndChild();
							}

							ImGui.EndChild();
                        }

                        ImGui.Unindent();

                        ImGui.EndGroup();
                    }
                }
                #endregion

                #region SETTINGS TAB

                using (var settingsTab = ImRaii.TabItem("Settings"))
                {
                    if (settingsTab)
                    {
                        ImGui.Spacing();
                        ImGui.Spacing();
                        ImGuiWindowFlags window_flags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.ChildWindow;
                        using (ImRaii.PushStyle(ImGuiStyleVar.ItemSpacing, new Vector2(0, 5)))
                        {
                            ImGui.BeginChild("ChildL", new System.Numerics.Vector2(ImGui.GetContentRegionAvail().X - ImGui.GetScrollX(), 300f), true, window_flags);

                            using (ImRaii.PushFont(UiBuilder.MonoFont))
                            using (ImRaii.PushColor(ImGuiCol.Text, ImGuiColors.ParsedGold))
                            {
                                ImGui.Text($"General options");
                            }

                            ImGui.Separator();

                            var enablePlugin = Service.Configuration.EnablePlugin;
                            if (ImGui.Checkbox("Enables this plugin.", ref enablePlugin))
                            {
                                Service.Configuration.EnablePlugin = enablePlugin;
                                Service.Configuration.Save();
                            }

                            if (ImGui.IsItemHovered())
                            {
                                ImGui.BeginTooltip();
                                ImGui.TextUnformatted("Completely disables the plugin's functionalities along with every combo when unchecked.");
                                ImGui.EndTooltip();
                            }

                            var autoJobChange = Service.Configuration.AutoJobChange;
                            if (ImGui.Checkbox("Automatically switch to your current job's tab upon opening the UI.", ref autoJobChange))
                            {
                                Service.Configuration.AutoJobChange = autoJobChange;
                                Service.Configuration.Save();
                            }

                            var bigComboIcons = Service.Configuration.BigComboIcons;
                            if (ImGui.Checkbox("Increase the size of icons for combos and features.", ref bigComboIcons))
                            {
                                Service.Configuration.BigComboIcons = bigComboIcons;
                                Service.Configuration.Save();
                            }

                            var bigJobIcons = Service.Configuration.BigJobIcons;
                            if (ImGui.Checkbox("Increase the size of icons for the jobs on the side bar.", ref bigJobIcons))
                            {
                                Service.Configuration.BigJobIcons = bigJobIcons;
                                Service.Configuration.Save();
                            }

                            var hideIcons = Service.Configuration.HideIcons;
                            if (ImGui.Checkbox("Hide icons for combos and features.", ref hideIcons))
                            {
                                Service.Configuration.HideIcons = hideIcons;
                                Service.Configuration.Save();
                            }

                            var hideChildren = Service.Configuration.HideChildren;
                            if (ImGui.Checkbox("Hide children of disabled combos and features.", ref hideChildren))
                            {
                                Service.Configuration.HideChildren = hideChildren;
                                Service.Configuration.Save();
							}

							var enableTheme = Service.Configuration.EnableTheme;
							if (ImGui.Checkbox("Enforce the custom theme.", ref enableTheme))
							{
								Service.Configuration.EnableTheme = enableTheme;
								Service.Configuration.Save();
							}

							var hideKoFi = Service.Configuration.HideKofi;
                            if (ImGui.Checkbox("Hide the Ko-Fi link.", ref hideKoFi))
                            {
                                Service.Configuration.HideKofi = hideKoFi;
                                Service.Configuration.Save();
                            }

                            ImGui.Spacing();
                            ImGui.Spacing();

                            if (ImGui.Button("Re-open the first time pop-up window"))
                            {
                                Service.Configuration.OneTimePopUp = true;
                                Plugin.oneTimeModal.IsOpen = true;
                                Service.Configuration.Save();
                            }

                            ImGui.EndChild();
                        }
                    }
                }
                #endregion

                #region CHANGELOG TAB

                using (var changelogTab = ImRaii.TabItem("Changelog"))
                {
                    if (changelogTab)
                    {
                        ImGui.BeginChild("scrolling", new Vector2(0, -1), true);

                        using (ImRaii.PushStyle(ImGuiStyleVar.ItemSpacing, new Vector2(0, 5)))
                        {
                            var changelog = Changelog.GetChangelog();

                            foreach (var (version, info) in changelog)
                            {
                                if (ImGui.CollapsingHeader(version, ImGuiTreeNodeFlags.DefaultOpen))
                                {
                                    ImGui.PushItemWidth(200);

                                    ImGui.PopItemWidth();


                                    using (ImRaii.PushColor(ImGuiCol.Text, this.shadedColor))
                                    {

                                        foreach (var text in info)
                                        {
                                            ImGui.BulletText(text);
                                        }
                                    }

                                    ImGui.Spacing();
                                }
                            }
                        }

                        ImGui.EndChild();
                    }
                }
                #endregion

                #region ABOUT TAB
                using (var aboutTab = ImRaii.TabItem("About"))
                {
                    if (aboutTab)
                    {
                        ImGui.Spacing();
                        ImGui.Spacing();

                        using (ImRaii.PushFont(UiBuilder.MonoFont))
                        using (ImRaii.PushColor(ImGuiCol.Text, ImGuiColors.DalamudWhite2))
                        {
                            ImGui.Text("Statistics for nerds");
                        }

                        ImGui.Separator();
                        ImGui.Spacing();

                        ImGui.BulletText($"{Enum.GetValues<CustomComboPreset>().Where(preset => (int)preset > 100 && preset != CustomComboPreset.Disabled && Service.Configuration.IsEnabled(preset)).Count()} combos are currently enabled.");
                        ImGui.Text($"{Enum.GetValues<CustomComboPreset>().Where(preset => (int)preset > 100 && preset != CustomComboPreset.Disabled).Count()} total combos are available.");

                        ImGui.Separator();
                        ImGui.Spacing();
                        ImGui.Spacing();

                        using (ImRaii.PushFont(UiBuilder.MonoFont))
                        using (ImRaii.PushColor(ImGuiCol.Text, ImGuiColors.DalamudWhite2))
                        {
                            ImGui.Text("GitHub Repository");
                        }

                        ImGui.Spacing();
                        ImGui.Spacing();

                        var url = "https://github.com/MKhayle/XIVComboPlugin";
                        if (ImGui.Button("Open the GitHub Repository URL"))
                        {
                            Process.Start(new ProcessStartInfo { FileName = "https://github.com/MKhayle/XIVComboPlugin", UseShellExecute = true });
                        }
                        ImGui.InputText("", ref url, 100, ImGuiInputTextFlags.ReadOnly);

                        ImGui.Spacing();
                        ImGui.Spacing();
                        using (ImRaii.PushFont(UiBuilder.MonoFont))
                        using (ImRaii.PushColor(ImGuiCol.Text, ImGuiColors.DalamudWhite2))
                        {
                            ImGui.Text("Contributors and special thanks");
                        }

                        ImGui.Separator();
                        ImGui.Spacing();

                        ImGui.BulletText("goat and the whole Dalamud team");
                        ImGui.BulletText("ff-meli for the initial concept");
                        ImGui.BulletText("attick for the original XIVCombo");
                        ImGui.BulletText("daemitus for the codebase data expansion");
                        ImGui.Spacing();
                        ImGui.Text("+ Khayle for taking over the project.");
                    }
                }
                #endregion

            }
        }


        ImGui.SameLine();
        ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetColumnWidth() - 80f - ImGui.GetScrollX()
                               - 2 * ImGui.GetStyle().ItemSpacing.X);

        if (!Service.Configuration.HideKofi)
        {
            using (ImRaii.PushColor(ImGuiCol.Button, ImGuiColors.DalamudRed))
            {
                if (ImGui.Button("My Ko-Fi link ♥"))
                {
                    Process.Start(new ProcessStartInfo { FileName = "https://ko-fi.com/khayle", UseShellExecute = true });
                }
            }

        }
    }

    private void DrawSection(CustomComboPreset preset, CustomComboInfoAttribute info, ref int i)
    {
        var enabled = Service.Configuration.IsEnabled(preset);
        var conflicts = Service.Configuration.GetConflicts(preset);
        var parent = Service.Configuration.GetParent(preset);
        string section = preset.GetAttribute<SectionComboAttribute>()?.Section;
        uint[] icons = [];

        ImGui.Spacing();
        ImGui.Spacing();
        using (ImRaii.PushFont(UiBuilder.MonoFont))
        using (ImRaii.PushColor(ImGuiCol.Text, ImGuiColors.ParsedOrange))
        {
            ImGui.Text(section);
        };
        ImGui.Separator();
        ImGui.Spacing();
    }

    private string DrawPreset(CustomComboPreset preset, CustomComboInfoAttribute info, string previousSection, ref int i)
    {
        var enabled = Service.Configuration.IsEnabled(preset);
        var conflicts = Service.Configuration.GetConflicts(preset);
        var parent = Service.Configuration.GetParent(preset);
        uint[] icons = [];
        string section = string.Empty;

        if (preset.GetAttribute<IconsComboAttribute>()?.Icons.Length > 0)
            icons = preset.GetAttribute<IconsComboAttribute>().Icons;

        if (preset.GetAttribute<SectionComboAttribute>()?.Section != null)
            section = preset.GetAttribute<SectionComboAttribute>().Section.ToString();

        if (preset.GetAttribute<SectionComboAttribute>()?.Section != null)
        {
            if (previousSection != preset.GetAttribute<SectionComboAttribute>()?.Section && previousSection != "child")
            {
                this.DrawSection(preset, info, ref i);
                previousSection = preset.GetAttribute<SectionComboAttribute>()?.Section;
            }
        }


        ImGui.PushItemWidth(200);

        if (ImGui.Checkbox(info.FancyName, ref enabled))
        {
            if (enabled)
            {
                this.EnableParentPresets(preset);
                Service.Configuration.EnabledActions.Add(preset);
                foreach (var conflict in conflicts)
                {
                    Service.Configuration.EnabledActions.Remove(conflict);
                }
            }
            else
            {
                Service.Configuration.EnabledActions.Remove(preset);
            }

            Service.Configuration.Save();
        }

        float scale = 1;
        if (Service.Configuration.BigComboIcons)
            scale = 1.3f;


        if (icons.Length > 0 && !Service.Configuration.HideIcons)
        {
            ImGui.SameLine();
            ImGui.SetCursorPosX(
              ImGui.GetCursorPosX()
              + ImGui.GetColumnWidth()
              - (icons.Length * ((24f * scale) + (float)ImGui.GetStyle().ItemSpacing.X))
              + ImGui.GetScrollX());


            int it = 0;
            foreach (var iconId in icons)
            {
                ImGui.AlignTextToFramePadding();
                bool isStatus = false;
                bool isUTL = false;
                string hoverName = string.Empty;
                ISharedImmediateTexture icon;

                // Workaround which will work until it won't work anymore
                if (iconId > 60000)
                {
                    icon = GetIcon(iconId);
                    isUTL = true;
                }
                else
                {
                    icon = GetSkillIcon(iconId);
                    if (icon == null)
                    {
                        isStatus = true;
                        icon = GetStatusIcon(iconId);
                    }
                }

                if (isStatus)
                {
                    ImGui.SetCursorPosY(ImGui.GetCursorPosY() - 4f);
                    ImGui.Image(icon.GetWrapOrEmpty().Handle, new System.Numerics.Vector2(24f * scale, 32f * scale));
                    ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 4f);
                    hoverName = GetStatusName(iconId);
                }
                else if (isUTL)
                {
                    ImGui.Image(GetIcon(IconsComboAttribute.Blank).GetWrapOrEmpty().Handle, new System.Numerics.Vector2(2f * scale, 24f * scale));
                    ImGui.SameLine(0, 0);
                    ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 3f);
                    ImGui.Image(icon.GetWrapOrEmpty().Handle, new System.Numerics.Vector2(20f * scale, 20f * scale));
                    ImGui.SetCursorPosY(ImGui.GetCursorPosY() - 3f);
                }
                else
                {
                    ImGui.Image(icon.GetWrapOrEmpty().Handle, new System.Numerics.Vector2(24f*scale, 24f*scale));
                    hoverName = GetSkillName(iconId);
                }

                if (hoverName != string.Empty)
                {
                    if (ImGui.IsItemHovered())
                    {
                        ImGui.BeginTooltip();
                        ImGui.TextUnformatted(hoverName);
                        ImGui.EndTooltip();
                    }
                }

                if (isUTL)
                {
                    ImGui.SameLine(0, 0);
                    ImGui.Image(GetIcon(IconsComboAttribute.Blank).GetWrapOrEmpty().Handle, new System.Numerics.Vector2(2f * scale, 24f * scale));
                }

                it++;

                if (icons.Count() != it)
                {
                    ImGui.SameLine();
                }
                else
                {
                    it = 0;
                }
            }

        }

        ImGui.PopItemWidth();

        using (ImRaii.PushColor(ImGuiCol.Text, this.shadedColor))
        {
        ImGui.TextWrapped($"{info.Description}");
        }

        ImGui.Spacing();

        if (conflicts.Length > 0 && enabled)
        {
            var conflictText = conflicts.Select(conflict =>
            {
                var conflictInfo = conflict.GetAttribute<CustomComboInfoAttribute>();
                return $" · {conflictInfo.FancyName}";
            }).Aggregate((t1, t2) => $"{t1}{t2}");

            if (conflictText.Length > 0)
            {
                ImGui.TextColored(ImGuiColors.DPSRed, $"Conflicts with {conflictText}");
                ImGui.Spacing();
            }
        }

        i++;

        var hideChildren = Service.Configuration.HideChildren;
        if (enabled || !hideChildren)
        {
            var children = this.presetChildren[preset];
            if (children.Length > 0)
            {
                ImGui.Indent();

                foreach (var (childPreset, childInfo) in children)
                    this.DrawPreset(childPreset, childInfo, "child", ref i);

                ImGui.Unindent();
            }
        }

        return section;
    }

    /// <summary>
    /// Iterates up a preset's parent tree, enabling each of them.
    /// </summary>
    /// <param name="preset">Combo preset to enabled.</param>
    private void EnableParentPresets(CustomComboPreset preset)
    {
        var parentMaybe = Service.Configuration.GetParent(preset);
        while (parentMaybe != null)
        {
            var parent = parentMaybe.Value;

            if (!Service.Configuration.EnabledActions.Contains(parent))
            {
                Service.Configuration.EnabledActions.Add(parent);
                foreach (var conflict in Service.Configuration.GetConflicts(parent))
                {
                    Service.Configuration.EnabledActions.Remove(conflict);
                }
            }

            parentMaybe = Service.Configuration.GetParent(parent);
        }
    }

    /// <summary>
    /// Returns a ISharedImmediateTexture for the appropriate job.
    /// </summary>
    /// <param name="jobID">ID of the job.</param>
    private static ISharedImmediateTexture GetJobIcon(byte jobID)
    {
        var iconID = 62100 + jobID;

        // Outside of bounds, either DoL, DoH, or we messed up.
        if (iconID < 62101 || iconID > 62142)
            iconID = 62145;
        // Adventurer
        if (jobID == 0)
            iconID = 62146;

        return GetIcon((uint)iconID);
    }

    /// <summary>
    /// Returns a ISharedImmediateTexture for the appropriate skill.
    /// </summary>
    /// <param name="skillID">ID of the skill.</param>
    private static ISharedImmediateTexture GetSkillIcon(uint skillID)
    {

        List<uint> whiteList = new List<uint>();

        var actionList = Service.DataManager.GameData.Excel.GetSheet<Action>();
        var skill = actionList.GetRow(skillID);
        // Check if the icon isn't Cure's AND isn't actually Cure
        if ((skill.Icon == 405 && skill.RowId != 120) || (!skill.IsPlayerAction && skill.ClassJobLevel == 0) && !whiteList.Contains(skillID))
            return null;
        return GetIcon((uint)skill.Icon);
    }

    /// <summary>
    /// Returns a ISharedImmediateTexture for the appropriate status.
    /// </summary>
    /// <param name="statusID">ID of the status.</param>
    private static ISharedImmediateTexture GetStatusIcon(uint statusID)
    {
        var statusList = Service.DataManager.GameData.Excel.GetSheet<Status>();
        var status = statusList.GetRow(statusID);
        return GetIcon((uint)status.Icon);
    }

    /// <summary>
    /// Returns the localized string name for the appropriate skill/status.
    /// </summary>
    /// <param name="skillID">ID of the skill.</param>
    private static string GetSkillName(uint skillID)
    {
        if (skillID > 60000)
            return String.Empty;

        Language language = (Language)Service.ClientState.ClientLanguage + 1;
        if (language != Language.English)
        {
            var enActionList = Service.DataManager.GameData.Excel.GetSheet<Action>(Language.English);
            var enSkill = enActionList.GetRow(skillID);
            var level = enSkill.ClassJobLevel != 0 ? $" (lvl {enSkill.ClassJobLevel})" : string.Empty;
            var actionList = Service.DataManager.GameData.Excel.GetSheet<Action>(language);
            var skill = actionList.GetRow(skillID);
            return $"{skill.Name}\n{enSkill.Name}{level}";
        }
        else
        {
            var actionList = Service.DataManager.GameData.Excel.GetSheet<Action>(language);
            var skill = actionList.GetRow(skillID);
            var level = skill.ClassJobLevel != 0 ? $" (lvl {skill.ClassJobLevel})" : string.Empty;
            return $"{skill.Name}{level}";
        }

    }

    /// <summary>
    /// Returns the localized string name for the appropriate skill/status.
    /// </summary>
    /// <param name="skillID">ID of the skill.</param>
    private static string GetStatusName(uint skillID)
    {
        if (skillID > 60000)
            return String.Empty;

        Language language = (Language)Service.ClientState.ClientLanguage + 1;
        var statusList = Service.DataManager.GameData.Excel.GetSheet<Status>(language);
        var status = statusList.GetRow(skillID);
        return status.Name.ExtractText();

    }

    /// <summary>
    /// Returns a ISharedImmediateTexture for the appropriate icon.
    /// </summary>
    /// <param name="iconID">ID of the icon.</param>
    private static ISharedImmediateTexture GetIcon(uint iconID)
        => Service.TextureProvider.GetFromGameIcon(new GameIconLookup(iconID, false, true));
}
