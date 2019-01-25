using System.Collections.Generic;
using PopForums.Repositories;

namespace PopForums.Services
{
	public interface IBanService
	{
		void BanIP(string ip);
		void RemoveIPBan(string ip);
		List<string> GetIPBans();
		bool IPIsBanned(string ip);
		void BanEmail(string email);
		void RemoveEmailBan(string email);
		List<string> GetEmailBans();
		bool EmailIsBanned(string email);
	}

	public class BanService : IBanService
	{
		public BanService(IBanRepository banRepsoitory)
		{
			_banRepository = banRepsoitory;
		}

		private readonly IBanRepository _banRepository;

		public void BanIP(string ip)
		{
			_banRepository.BanIP(ip);
		}

		public void RemoveIPBan(string ip)
		{
			_banRepository.RemoveIPBan(ip);
		}

		public List<string> GetIPBans()
		{
			return _banRepository.GetIPBans();
		}

		public bool IPIsBanned(string ip)
		{
			return _banRepository.IPIsBanned(ip);
		}

		public void BanEmail(string email)
		{
			_banRepository.BanEmail(email);
		}

		public void RemoveEmailBan(string email)
		{
			_banRepository.RemoveEmailBan(email);
		}

		public List<string> GetEmailBans()
		{
			return _banRepository.GetEmailBans();
		}

		public bool EmailIsBanned(string email)
		{
			return _banRepository.EmailIsBanned(email);
		}
	}
}