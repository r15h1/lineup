namespace LineUp.Core.Commands {
	public interface IClubCommandFactory
    {
		ICommand CreateTeamAdditionCommand(Team team);
		ICommand CreateTeamRemovalCommand(Team team);
	}
}
