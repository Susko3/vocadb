import { AlbumRepository } from '@/Repositories/AlbumRepository';
import { GlobalValues } from '@/Shared/GlobalValues';
import {
	AlbumSearchStore,
	AlbumSortRule,
} from '@/Stores/Search/AlbumSearchStore';
import { CommonSearchStore } from '@/Stores/Search/CommonSearchStore';
import {
	includesAny,
	RouteParamsChangeEvent,
	RouteParamsStore,
} from '@vocadb/route-sphere';
import Ajv, { JSONSchemaType } from 'ajv';

export interface ArtistAlbumsRouteParams {
	page?: number;
	pageSize?: number;
	sort?: AlbumSortRule;
	viewMode?: string /* TODO: enum */;
}

const clearResultsByQueryKeys: (keyof ArtistAlbumsRouteParams)[] = [
	'pageSize',

	'sort',
];

// TODO: Use single Ajv instance. See https://ajv.js.org/guide/managing-schemas.html.
const ajv = new Ajv({ coerceTypes: true });

// TODO: Make sure that we compile schemas only once and re-use compiled validation functions. See https://ajv.js.org/guide/getting-started.html.
const schema: JSONSchemaType<ArtistAlbumsRouteParams> = require('./ArtistAlbumsRouteParams.schema');
const validate = ajv.compile(schema);

export class ArtistAlbumsStore
	extends AlbumSearchStore
	implements RouteParamsStore<ArtistAlbumsRouteParams> {
	public constructor(values: GlobalValues, albumRepo: AlbumRepository) {
		super(
			new CommonSearchStore(values, undefined!),
			values,
			albumRepo,
			undefined!,
		);
	}

	public get routeParams(): ArtistAlbumsRouteParams {
		return {
			page: this.paging.page,
			pageSize: this.paging.pageSize,
			sort: this.sort,
			viewMode: this.viewMode,
		};
	}
	public set routeParams(value: ArtistAlbumsRouteParams) {
		this.paging.page = value.page ?? 1;
		this.paging.pageSize = value.pageSize ?? 10;
		this.sort = value.sort ?? AlbumSortRule.Name;
		this.viewMode = value.viewMode ?? 'Details';
	}

	public validateRouteParams = (data: any): data is ArtistAlbumsRouteParams => {
		return validate(data);
	};

	public onRouteParamsChange = (
		event: RouteParamsChangeEvent<ArtistAlbumsRouteParams>,
	): void => {
		const clearResults = includesAny(clearResultsByQueryKeys, event.keys);

		if (!event.popState && clearResults) this.paging.goToFirstPage();

		this.updateResults(clearResults);
	};
}
