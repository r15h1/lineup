using LineUp.Lib.Requests;

namespace LineUp.Lib.Repositories {
	public interface IMemberRepository {
		void AddPlayer(PlayerAdditionRequest request);
	}
}
