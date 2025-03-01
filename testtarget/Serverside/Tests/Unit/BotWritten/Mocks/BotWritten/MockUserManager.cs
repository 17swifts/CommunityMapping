/*
 * @bot-written
 *
 * WARNING AND NOTICE
 * Any access, download, storage, and/or use of this source code is subject to the terms and conditions of the
 * Full Software Licence as accepted by you before being granted access to this source code and other materials,
 * the terms of which can be accessed on the Codebots website at https://codebots.com/full-software-licence. Any
 * commercial use in contravention of the terms of the Full Software Licence may be pursued by Codebots through
 * licence termination and further legal action, and be required to indemnify Codebots for any loss or damage,
 * including interest and costs. You are deemed to have accepted the terms of the Full Software Licence on any
 * access, download, storage, and/or use of this source code.
 *
 * BOT WARNING
 * This file is bot-written.
 * Any changes out side of "protected regions" will be lost next time the bot makes any changes.
 */

using System;
using Cis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace ServersideTests.Mocks
{
	public class MockUserManager : Mock<UserManager<User>>
	{
		public MockUserManager(
			IUserStore<User> userStore,
			IOptions<IdentityOptions> identityOptions,
			IPasswordHasher<User> passwordHasher,
			IUserValidator<User>[] userValidator,
			IPasswordValidator<User>[] passwordValidator,
			ILookupNormalizer lookupNormalizer,
			IdentityErrorDescriber identityErrorDescriber,
			IServiceProvider serviceProvider,
			ILogger<UserManager<User>> logger) :
			base(
			userStore,
			identityOptions,
			passwordHasher,
			userValidator,
			passwordValidator,
			lookupNormalizer,
			identityErrorDescriber,
			serviceProvider,
			logger)
		{

		}

		public static MockUserManager GetMockUserManager(
			IUserStore<User> userStore = null,
			IOptions<IdentityOptions> identityOptions = null,
			IPasswordHasher<User> passwordHasher = null,
			IUserValidator<User>[] userValidator = null,
			IPasswordValidator<User>[] passwordValidator = null,
			ILookupNormalizer lookupNormalizer = null,
			IdentityErrorDescriber identityErrorDescriber = null,
			IServiceProvider serviceProvider = null,
			ILogger<UserManager<User>> logger = null)
		{
			return new MockUserManager(
				userStore ?? new Mock<IUserStore<User>>().Object,
				identityOptions ?? new Mock<IOptions<IdentityOptions>>().Object,
				passwordHasher ?? new Mock<IPasswordHasher<User>>().Object,
				userValidator ?? new IUserValidator<User>[0],
				passwordValidator ?? new IPasswordValidator<User>[0],
				lookupNormalizer ?? new Mock<ILookupNormalizer>().Object,
				identityErrorDescriber ?? new Mock<IdentityErrorDescriber>().Object,
				serviceProvider ?? new Mock<IServiceProvider>().Object,
				logger ?? new Mock<ILogger<UserManager<User>>>().Object);
		}
	}
}
