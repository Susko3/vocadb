import { WebhookContract } from '@/DataContracts/WebhookContract';
import { HttpClient } from '@/Shared/HttpClient';
import { UrlMapper } from '@/Shared/UrlMapper';

export interface IPRuleContract {
	address?: string;
	created?: string;
	id?: number;
	notes?: string;
}

export class AdminRepository {
	public constructor(
		private readonly httpClient: HttpClient,
		private readonly urlMapper: UrlMapper,
	) {}

	// eslint-disable-next-line no-empty-pattern
	public getIPRules = ({}: {}): Promise<IPRuleContract[]> => {
		return this.httpClient.get<IPRuleContract[]>(
			this.urlMapper.mapRelative('/api/ip-rules'),
		);
	};

	public saveIPRules = ({
		ipRules,
	}: {
		ipRules: IPRuleContract[];
	}): Promise<void> => {
		return this.httpClient.put<void>(
			this.urlMapper.mapRelative('/api/ip-rules'),
			ipRules,
		);
	};

	public addIpToBanList = ({
		rule,
	}: {
		rule: IPRuleContract;
	}): Promise<boolean> => {
		return this.httpClient.post<boolean>(
			this.urlMapper.mapRelative('/api/ip-rules'),
			rule,
		);
	};

	public checkSFS = ({ ip }: { ip: string }): Promise<string> => {
		return this.httpClient.get<string>(
			this.urlMapper.mapRelative('/Admin/CheckSFS'),
			{ ip: ip },
		);
	};

	// eslint-disable-next-line no-empty-pattern
	public getTempBannedIps = ({}: {}): Promise<string[]> => {
		return this.httpClient.get<string[]>(
			this.urlMapper.mapRelative('/api/admin/tempBannedIPs'),
		);
	};

	// eslint-disable-next-line no-empty-pattern
	public getWebhooks = ({}: {}): Promise<WebhookContract[]> => {
		return this.httpClient.get<WebhookContract[]>(
			this.urlMapper.mapRelative('/api/webhooks'),
		);
	};

	public saveWebhooks = ({
		webhooks,
	}: {
		webhooks: WebhookContract[];
	}): Promise<void> => {
		var url = this.urlMapper.mapRelative('/api/webhooks');
		return this.httpClient.put<void>(url, webhooks);
	};
}
