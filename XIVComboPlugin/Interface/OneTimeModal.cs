using System.Numerics;

using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Style;
using Dalamud.Interface.Windowing;
using Dalamud.Bindings.ImGui;
using XIVCombo;

namespace XIVCombo.Interface
{
	public class OneTimeModal : Window
	{

		public readonly XIVCombo Plugin;

		public OneTimeModal(XIVCombo Plugin)
		: base("popup")
		{
			this.Plugin = Plugin;
			RespectCloseHotkey = false;
			AllowPinning = false;
			ShowCloseButton = false;
			Flags = ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoDocking | ImGuiWindowFlags.NoTitleBar;
			Size = new Vector2(480, 700);
			SizeCondition = ImGuiCond.Always;
		}

		public override bool DrawConditions()
		{
			if (Service.Configuration is { OneTimePopUp: true }) return true;
			return false;
		}

		/// <inheritdoc/>
		public override void Draw()
		{

			ImGui.PushFont(UiBuilder.MonoFont);
			ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.ParsedGold);
			ImGui.Text($"Welcome to XIVCombo v{Service.Interface.Manifest.AssemblyVersion}!");
			ImGui.PopStyleColor();
			ImGui.PopFont();
			ImGui.Spacing();
			ImGui.Text("This is the first time you're using the new version of XIVCombo.");
			ImGui.Text("With the introduction of new combos and features, an ever-growing list of jobs,\nthis plugin ended up having to be reworked for better UI & clarity.");
			ImGui.Text("First of all, it is recommended to open up the main interface and check it out.");
			ImGui.Spacing();
			ImGui.Spacing();

			if (ImGui.Button("Open the Main Interface"))
			{
				Plugin.configWindow.Toggle();
				Service.Configuration.Save();
			}

			ImGui.Spacing();
			ImGui.Separator();
			ImGui.Spacing();
			ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.ParsedGold);
			ImGui.Text("What's new?");
			ImGui.PopStyleColor();
			ImGui.Spacing();
			ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.ParsedGold);
			ImGui.Text("New UI & settings");
			ImGui.PopStyleColor();
			ImGui.BulletText("You can check them out below, actually. How neat!");
			ImGui.BulletText("By default, icons are small for low-resolution users.\n2k & 4k enjoyers have options for bigger icons.");
			ImGui.BulletText("Icons may cause a loss of FPS when the Combos tab is open.\nThat shouldn't happen when it matters, right?");
			ImGui.BulletText("A Changelog tab is available to see new updates.");
			ImGui.BulletText("An About tab is available for credits.");

			ImGui.Spacing();
			ImGui.Text("Please set up your ideal configuration.\nDo not worry, you will be able to change those later.");

			ImGui.Spacing();
			ImGui.Spacing();

			ImGuiWindowFlags window_flags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.ChildWindow;
			ImGui.PushStyleVar(ImGuiStyleVar.ChildRounding, 5f);
			ImGui.BeginChild("ModalSettings", new Vector2(ImGui.GetContentRegionAvail().X - ImGui.GetScrollX(), 175f), true, window_flags);

			ImGui.PushFont(UiBuilder.MonoFont);
			ImGui.PushStyleColor(ImGuiCol.Text, ImGuiColors.ParsedGold);
			ImGui.Text($"General options");
			ImGui.PopStyleColor();
			ImGui.PopFont();
			ImGui.Separator();

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

			var enableTheme = Service.Configuration.EnableTheme;
			if (ImGui.Checkbox("Enforce the custom theme.", ref enableTheme))
			{
				Service.Configuration.EnableTheme = enableTheme;
				Service.Configuration.Save();
			}

			var hideIcons = Service.Configuration.HideIcons;
			if (ImGui.Checkbox("Hide icons for combos and features.", ref hideIcons))
			{
				Service.Configuration.HideIcons = hideIcons;
				Service.Configuration.Save();
			}

			ImGui.EndChild();
			ImGui.PopStyleVar();


			ImGui.Text("One last thing. If you used to use XIVCombo before, your settings\nprobably haven't been imported from the previous version.");
			ImGui.Text("You should check them. Better be safe than sorry!");
			ImGui.Spacing();
			ImGui.Spacing();

			if (ImGui.Button("Save and Close (you will be able to reopen this window later in the settings)"))
			{
				Service.Configuration.OneTimePopUp = false;
				Service.Configuration.Save();
			}

			ImGui.Spacing();
			ImGui.Spacing();
		}
	}
}
